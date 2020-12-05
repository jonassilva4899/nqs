using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leega.Domain.Domain;
using Leega.Entity;
using Leega.Entity.Entity;
using Leega.Entity.Enums;
using Leega.Entity.Repositories.Interfaces;

namespace Leega.Domain.Service
{
    public class OrganizacaoService
    {
        private readonly IOrganizacaoRepository _organizacaoRepository;
        private readonly IRepository<OrganizacaoUsuario> _organizacaoPessoaRepository;
        private readonly IPessoaRepository _pessoaRepository;

        public OrganizacaoService(IOrganizacaoRepository organizacaoRepository, IRepository<OrganizacaoUsuario> organizacaoPessoaRepository, IPessoaRepository pessoaRepository)

        {
            _organizacaoRepository = organizacaoRepository;
            _organizacaoPessoaRepository = organizacaoPessoaRepository;
            _pessoaRepository = pessoaRepository;
        }

        //public async Task<Guid> SalvarOuAtualizar(OrganizacaoViewModel organizacaoViewModel)
        //{
        //    var organizacao = new Organizacao();
        //    if (organizacaoViewModel.Id.HasValue)
        //    {
        //        organizacao = _organizacaoRepository.GetSingleOrDefault(x => x.Id == organizacaoViewModel.Id);
        //        if (organizacao != null)
        //        {
        //            organizacao.Nome = organizacaoViewModel.Nome;
        //            organizacao.Foto = organizacaoViewModel.Foto;
        //            organizacao.Descricao = organizacaoViewModel.Descricao;
        //            organizacao.Localizacao = organizacaoViewModel.Localizacao;
        //            organizacao.DataCriacao = organizacaoViewModel.DataCriacao;
        //            organizacao.ResponsavelCriacao = organizacaoViewModel.ResponsavelCriacao;
        //            organizacao.DataEdicao = organizacaoViewModel.DataEdicao;
        //            organizacao.ResponsavelEdicao = organizacaoViewModel.ResponsavelEdicao;

        //            _organizacaoRepository.Update(organizacao);
        //        }
        //    }
        //    else
        //    {
        //        organizacao = new Organizacao()
        //        {
        //            Nome = organizacaoViewModel.Nome,
        //            Foto = organizacaoViewModel.Foto,
        //            Descricao = organizacaoViewModel.Descricao,
        //            Localizacao = organizacaoViewModel.Localizacao,
        //            DataCriacao = organizacaoViewModel.DataCriacao,
        //            ResponsavelCriacao = organizacaoViewModel.ResponsavelCriacao,
        //            DataEdicao = organizacaoViewModel.DataEdicao,
        //            ResponsavelEdicao = organizacaoViewModel.ResponsavelEdicao
        //        };
        //        _organizacaoRepository.Add(organizacao);

        //    }

        //    _organizacaoRepository.Save();
        //    await SalvarOuAtualizarOrganizacaoPessoas(organizacao.Id, organizacaoViewModel.IdUsuario, organizacaoViewModel.IdPessoas, organizacao.ResponsavelCriacao);
        //    return organizacao.Id;
        //}
        //private async Task SalvarOuAtualizarOrganizacaoPessoas(Guid idOrganizacao, Guid idUsuario, List<Guid> idPessoas, Guid responsavelCriacao)
        //{
        //    foreach (var idPessoa in idPessoas)
        //    {
        //        var organizacaoPessoa = await _organizacaoRepository.BuscaOrganizacaoPorPessoa(idOrganizacao, idPessoa);
        //        if (organizacaoPessoa == null)
        //        {
        //            organizacaoPessoa = new OrganizacaoUsuario();
        //            organizacaoPessoa.IdOrganizacao = idOrganizacao;
        //            organizacaoPessoa.IdUsuario = idUsuario;
        //            organizacaoPessoa.IdPessoa = idPessoa;
        //            organizacaoPessoa.Ativo = true;
        //            organizacaoPessoa.UsuarioPlataforma = true;
        //            organizacaoPessoa.DataCriacao = DateTime.Now;
        //            organizacaoPessoa.ResponsavelCriacao = responsavelCriacao;
        //            _organizacaoPessoaRepository.Add(organizacaoPessoa);
        //        }
        //    }

        //    _organizacaoPessoaRepository.Save();
        //}

        public async Task<bool> AtualizarFoto(Guid id, string urlImagem)
        {
            try
            {
                var organizacao = _organizacaoRepository.Get(id);

                if (organizacao == null)
                {
                    return false;
                }

                organizacao.Foto = urlImagem;

                _organizacaoRepository.Update(organizacao);
                _organizacaoRepository.Save();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<OrganizacaoViewModel>> Listar(Guid idUsuario, OrganizacaoUsuarioRoleEnum roleEnum)
        {
            try
            {
                List<Organizacao> organizacoes;
                if (roleEnum == OrganizacaoUsuarioRoleEnum.GoobeeAdmin)
                {
                    organizacoes = await _organizacaoRepository.ListarGoobeeAdmin();
                }
                else
                {
                    organizacoes = await _organizacaoRepository.Listar(idUsuario);
                }

                var retorno = organizacoes.OrderBy(x => x.Nome).Select(x => new OrganizacaoViewModel()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Foto = x.Foto,
                    Descricao = x.Descricao,
                    Localizacao = x.Localizacao,
                    DataCriacao = x.DataCriacao,
                    ResponsavelCriacao = x.ResponsavelCriacao,
                    DataEdicao = x.DataEdicao,
                    ResponsavelEdicao = x.ResponsavelEdicao,
                }).ToList();

                return retorno;

            }
            catch (Exception e)
            {
                return new List<OrganizacaoViewModel>();
            }
        }

        public async Task<OrganizacaoViewModel> Selecionar(Guid idOrganizacao)
        {
            try
            {
                var organizacao = await _organizacaoRepository.Selecionar(idOrganizacao);
                var retorno = new OrganizacaoViewModel()
                {
                    Id = organizacao.Id,
                    Nome = organizacao.Nome,
                    Foto = organizacao.Foto,
                    Descricao = organizacao.Descricao,
                    Localizacao = organizacao.Localizacao,
                    DataCriacao = organizacao.DataCriacao,
                    ResponsavelCriacao = organizacao.ResponsavelCriacao,
                    DataEdicao = organizacao.DataEdicao,
                    ResponsavelEdicao = organizacao.ResponsavelEdicao,
                    Pessoas = organizacao.Pessoas.Select(x => new ResumoPessoaViewModel()
                    {
                        Id = x.IdPessoa,
                        Nome = x.Pessoa.Nome,
                        Email = x.Pessoa.Email,
                        Status = x.Pessoa.Status
                    }).ToList()
                };

                return retorno;

            }
            catch (Exception e)
            {
                return new OrganizacaoViewModel();
            }
        }

        public async Task<List<OrganizacaoUsuario>> ListarOrganizacoesUsuario(Guid idUsuario)
        {
            var organizacaoUsuario = _organizacaoPessoaRepository.Find(x => x.IdUsuario == idUsuario).ToList();
            return organizacaoUsuario;
        }

        public async Task<IEnumerable<OrganizacaoUsuario>> ListarOrganizacoesUsuarioEmail(string email)
        {
            return _organizacaoPessoaRepository.Find(x => x.Usuario.Login.Equals(email));

        }

        public async Task<OrganizacaoUsuario> ListarOrganizacoesGoobeeAdmin(Guid idUsuario)
        {
            var organizacaoUsuario = _organizacaoPessoaRepository.Find(x => x.IdUsuario == idUsuario).ToList();
            return organizacaoUsuario.FirstOrDefault();
        }
    }
}