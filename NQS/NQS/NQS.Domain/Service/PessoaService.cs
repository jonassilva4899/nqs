using AutoMapper;
using Leega.Domain;
using Leega.Domain.Utils;
using Leega.Entity;
using Leega.Entity.Entity;
using Leega.Entity.Enums;
using Leega.Entity.Repositories.Interfaces;
using Leega.Entity.UnitofWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Leega.Entity.Migrations;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using Time = Leega.Entity.Time;

namespace Leega.Domain.Service
{
    public class PessoaService<Tv, Te> : GenericServiceAsync<Tv, Te>
                                               where Tv : PessoaViewModel
                                               where Te : Pessoa
    {
        private readonly EnvioDeEmailService _envioEmailService;
        private readonly TokenService _tokenService;
        //private readonly MediaSentimentoService _mediaSentimentoService;
        IPessoaRepository _pessoaRepository;
        ITimeRepository _timeRepository;
        IOrganizacaoPessoaRepository _organizacaoPessoaRepository;
        //IRepository<Motivador> _motivadorRepository;
        IRepository<Usuario> _usuarioRepository;
        IRepository<Convite> _conviteRepository;
        IRepository<ConviteHistorico> _conviteHistoricoRepository;
        IRepository<Organizacao> _organizacaoRepository;
        IRepository<OrganizacaoUsuarioRole> _organizacaoRoleRepository;
        IRepository<TimePessoa> _timePessoasRepository;
        //IRepository<PessoaMotivador> _pessoaMotivadoresRepository;

        public PessoaService(IUnitOfWork unitOfWork, IMapper mapper,
                             //EnvioDeEmailService envioEmailService,
                             TokenService tokenService,
                             //MediaSentimentoService mediaSentimentoService,
                             IPessoaRepository pessoaRepository,
                             ITimeRepository timeRepository,
                             IOrganizacaoPessoaRepository organizacaoPessoaRepository,
                             //IRepository<Motivador> motivadorRepository,
                             IRepository<Usuario> usuarioRepository,
                             IRepository<Convite> conviteRepository,
                             IRepository<ConviteHistorico> conviteHistoricoRepository,
                             IRepository<Organizacao> organizacaoRepository,
                             IRepository<OrganizacaoUsuarioRole> organizacaoRoleRepository)
                             //IRepository<TimePessoa> timePessoasRepository, IRepository<PessoaMotivador> pessoaMotivadoresRepository)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;

            if (_pessoaRepository == null)
                _pessoaRepository = pessoaRepository;

            if (_timeRepository == null)
                _timeRepository = timeRepository;

            if (_organizacaoPessoaRepository == null)
                _organizacaoPessoaRepository = organizacaoPessoaRepository;

            //_envioEmailService = envioEmailService;
            _tokenService = tokenService;
            //_mediaSentimentoService = mediaSentimentoService;
            //_motivadorRepository = motivadorRepository;
            _usuarioRepository = usuarioRepository;
            _conviteRepository = conviteRepository;
            _conviteHistoricoRepository = conviteHistoricoRepository;
            _organizacaoRepository = organizacaoRepository;
            _organizacaoRoleRepository = organizacaoRoleRepository;
            //_timePessoasRepository = timePessoasRepository;
            //_pessoaMotivadoresRepository = pessoaMotivadoresRepository;
        }

        public async Task<List<PessoasAtivasViewModel>> ListarUsuariosAtivos(Guid? idPessoa, Guid idOrganizacao)
        {
            var pessoasAtivas = _pessoaRepository.PegarTodasPessoasNaoInclusivoSemUsuario(idPessoa, idOrganizacao);

            List<PessoasAtivasViewModel> pessoas = new List<PessoasAtivasViewModel>();
            foreach (var elem in pessoasAtivas)
            {
                var pessoa = new PessoasAtivasViewModel();
                pessoa.Id = elem.Id;
                pessoa.Nome = elem.Nome;
                pessoa.Email = elem.Email;
                pessoa.Status = elem.Status;

                pessoas.Add(pessoa);
            }

            return pessoas.OrderBy(x => x.Nome).ToList();
        }

        public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>> AdicionarPessoa(PessoaAdicionarViewModel pessoa, Guid idOrganizacao)
        {
            RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>();
            try
            {
                var pessoaExistente = await _pessoaRepository.BuscarPorEmail(pessoa.Pessoa.Email);
                var pessoaInserir = await ModelarPessoa(pessoa.Pessoa, idOrganizacao);

                var entityPessoa = pessoaExistente ?? pessoaInserir;

                if (pessoaExistente != null && pessoaExistente.Organizacoes.Any(x => x.IdOrganizacao == idOrganizacao))
                {
                    return new RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>()
                    {
                        ExibicaoMensagem = new ExibicaoMensagemViewModel()
                        {
                            StatusCode = 400,
                            MensagemCurta = "Usuário já existe!"
                        }
                    };
                }

                Guid idOrganizacaoRole = Guid.Empty;
                if (pessoa.Pessoa.NivelPermissao != null)
                {
                    idOrganizacaoRole = _organizacaoRoleRepository.Find(x => x.Role == pessoa.Pessoa.NivelPermissao).SingleOrDefault().Id;
                    if (pessoa.Pessoa.NivelPermissao == OrganizacaoUsuarioRoleEnum.GoobeeAdmin)
                    {
                        entityPessoa.GoobeeAdmin = true;
                    }
                }

                if (pessoaExistente == null)
                {
                    _pessoaRepository.Add(entityPessoa);
                }

                if (entityPessoa.TimePessoas.Any(x => pessoaInserir.TimePessoas.All(y => y.IdTime != x.IdTime)))
                {
                    pessoaInserir.TimePessoas = pessoaInserir.TimePessoas.Select(x =>
                    {
                        x.IdPessoa = entityPessoa.Id;
                        return x;
                    }).ToList();

                    _timePessoasRepository.AddRange(pessoaInserir.TimePessoas);
                }


                if (pessoa.eUsuario)
                {
                    //var retorno = await ConfiguraUsuario(entityPessoa, pessoa.PessoaRequisitando, idOrganizacao, pessoa.eUsuario, pessoa.eContaGoogle, pessoa.Pessoa.FuncaoPrincipal, idOrganizacaoRole, pessoa.Pessoa.Status);

                    //if (retorno.ExibicaoMensagem != null)
                    //{
                    //    return retorno;
                    //}
                }
                else
                {
                    var usuarioOrganizacaoExistente = await _organizacaoPessoaRepository.BuscarPorEmailPessoa(entityPessoa.Email, idOrganizacao);

                    if (usuarioOrganizacaoExistente == null)
                    {
                        var usuarioOrganizacao = new OrganizacaoUsuario();
                        usuarioOrganizacao.IdOrganizacao = idOrganizacao;
                        usuarioOrganizacao.IdUsuario = null;
                        usuarioOrganizacao.IdPessoa = entityPessoa.Id;
                        usuarioOrganizacao.FuncaoPrincipal = pessoa.Pessoa.FuncaoPrincipal;
                        usuarioOrganizacao.UsuarioPlataforma = false;
                        usuarioOrganizacao.Ativo = true;
                        usuarioOrganizacao.DataCriacao = DateTime.Now;
                        usuarioOrganizacao.ResponsavelCriacao = pessoa.PessoaRequisitando;
                        usuarioOrganizacao.IdOrganizacaoUsuarioRole = idOrganizacaoRole;
                        _organizacaoPessoaRepository.Add(usuarioOrganizacao);
                    }
                    else
                    {
                        usuarioOrganizacaoExistente.IdPessoa = entityPessoa.Id;
                        usuarioOrganizacaoExistente.UsuarioPlataforma = true;
                        usuarioOrganizacaoExistente.Ativo = entityPessoa.Status;
                        usuarioOrganizacaoExistente.FuncaoPrincipal = pessoa.Pessoa.FuncaoPrincipal;
                        usuarioOrganizacaoExistente.IdOrganizacaoUsuarioRole = idOrganizacaoRole;
                        _organizacaoPessoaRepository.Update(usuarioOrganizacaoExistente);
                    }

                    _organizacaoPessoaRepository.Save();
                }

                _pessoaRepository.Save();
                _timePessoasRepository.Save();
                await _unitOfWork.SaveAsync();

                retornoController.Objeto = entityPessoa.Id;

                return retornoController;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>> ConfiguraUsuarioPerfil(Pessoa entityPessoa, PerfilEditarViewModel pessoaEditar, Guid idOrganizacao, Guid idOrganizacaoRole)
        {
            RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>();

            var usuarioExistente = _usuarioRepository.GetSingleOrDefault(x => x.Login == entityPessoa.Email);

            if (usuarioExistente == null)
            {
                usuarioExistente = await CriarUsuario(entityPessoa, pessoaEditar.eContaGoogle);
                if (usuarioExistente == null)
                {
                    ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                    {
                        Cabecalho = "Erro ao criar usuário",
                        MensagemCurta = "Erro ao criar usuário",
                        Detalhes = "Não foi possível criar usuário.",
                        StatusCode = StatusCodes.Status204NoContent
                    };

                    retornoController.ExibicaoMensagem = exibicaoMensagem;
                    return retornoController;
                }

                if (entityPessoa.Organizacoes != null && entityPessoa.Organizacoes.Any(x => x.IdOrganizacao == idOrganizacao))
                {
                    var usuarioOrganizacao = entityPessoa.Organizacoes.SingleOrDefault(x => x.IdOrganizacao == idOrganizacao);
                    usuarioOrganizacao.IdOrganizacao = idOrganizacao;
                    usuarioOrganizacao.FuncaoPrincipal = pessoaEditar.FuncaoPrincipal;
                    usuarioOrganizacao.IdUsuario = usuarioExistente.Id;
                    usuarioOrganizacao.IdPessoa = entityPessoa.Id;
                    usuarioOrganizacao.UsuarioPlataforma = true;
                    usuarioOrganizacao.Ativo = entityPessoa.Status;
                    usuarioOrganizacao.IdOrganizacaoUsuarioRole = idOrganizacaoRole;
                    _organizacaoPessoaRepository.Update(usuarioOrganizacao);
                }
                else
                {
                    var usuarioOrganizacao = new OrganizacaoUsuario();
                    usuarioOrganizacao.IdOrganizacao = idOrganizacao;
                    usuarioOrganizacao.FuncaoPrincipal = pessoaEditar.FuncaoPrincipal;
                    usuarioOrganizacao.IdUsuario = usuarioExistente.Id;
                    usuarioOrganizacao.IdPessoa = entityPessoa.Id;
                    usuarioOrganizacao.UsuarioPlataforma = true;
                    usuarioOrganizacao.Ativo = entityPessoa.Status;
                    usuarioOrganizacao.DataCriacao = DateTime.Now;
                    usuarioOrganizacao.ResponsavelCriacao = pessoaEditar.IdResponsavelEdicao;
                    usuarioOrganizacao.IdOrganizacaoUsuarioRole = idOrganizacaoRole;
                    _organizacaoPessoaRepository.Add(usuarioOrganizacao);
                }

                //salvar os convites
                var convite = await CriarConvite(entityPessoa, pessoaEditar.IdResponsavelEdicao, idOrganizacao);

                if (convite == null)
                {
                    ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                    {
                        Cabecalho = "Erro ao criar convite",
                        MensagemCurta = "Erro ao criar convite",
                        Detalhes = "Não foi possível criar convite para criação de usuário.",
                        StatusCode = StatusCodes.Status204NoContent
                    };

                    retornoController.ExibicaoMensagem = exibicaoMensagem;
                    return retornoController;
                }

                _usuarioRepository.Save();
                _organizacaoPessoaRepository.Save();

                //pegar link do convite
                var linkConvite = await _envioEmailService.GerarLink(convite.ConvitesHistorico.FirstOrDefault().Id,
                    convite.ConvitesHistorico.FirstOrDefault().Token, "registro-pessoa");

                //emailService
                var envioConvite = await _envioEmailService.EnvioConvite(convite, linkConvite);

                convite.ConvitesHistorico.FirstOrDefault().FoiEnviado = envioConvite.Resposta;
                convite.ConvitesHistorico.FirstOrDefault().MensagemResultadoNotificacao = envioConvite.Mensagem;

                if (envioConvite.Resposta == false)
                {
                    ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                    {
                        Cabecalho = "Erro ao enviar convite",
                        MensagemCurta = "Erro ao enviar convite",
                        Detalhes = envioConvite.Mensagem,
                        StatusCode = StatusCodes.Status500InternalServerError
                    };

                    retornoController.ExibicaoMensagem = exibicaoMensagem;

                    return retornoController;
                }
            }
            else
            {
                var usuarioOrganizacaoExistente = await _organizacaoPessoaRepository.BuscarPorEmailPessoa(usuarioExistente.Login, idOrganizacao);
                if (usuarioOrganizacaoExistente == null)
                {
                    var usuarioOrganizacao = new OrganizacaoUsuario();
                    usuarioOrganizacao.IdOrganizacao = idOrganizacao;
                    usuarioOrganizacao.IdUsuario = usuarioExistente.Id;
                    usuarioOrganizacao.IdPessoa = entityPessoa.Id;
                    usuarioOrganizacao.FuncaoPrincipal = pessoaEditar.FuncaoPrincipal;
                    usuarioOrganizacao.UsuarioPlataforma = pessoaEditar.eUsuario;
                    usuarioOrganizacao.Ativo = entityPessoa.Status;
                    usuarioOrganizacao.DataCriacao = DateTime.Now;
                    usuarioOrganizacao.ResponsavelCriacao = pessoaEditar.IdResponsavelEdicao;
                    usuarioOrganizacao.IdOrganizacaoUsuarioRole = idOrganizacaoRole;

                    _organizacaoPessoaRepository.Add(usuarioOrganizacao);

                    var organizacao = _organizacaoRepository.GetSingleOrDefault(x => x.Id == idOrganizacao);
                    Notificacao notificacao = new Notificacao()
                    {
                        Titulo = "Você entrou em uma Organização",
                        Mensagem = entityPessoa.Nome + " você entrou para a organização " + organizacao.Nome,
                        Tipo = "Notificacao",
                        ConfirmacaoLeitura = false,
                        EnviadoPorEmail = false,
                        DataCriacao = DateTime.Now,
                        ResponsavelCriacao = pessoaEditar.IdResponsavelEdicao,
                        DataEdicao = DateTime.Now,
                        ResponsavelEdicao = pessoaEditar.IdResponsavelEdicao,
                        IdOrganizacao = idOrganizacao
                    };


                    NotificacaoUsuario notificacaoUsuario = new NotificacaoUsuario()
                    {
                        Notificacao = notificacao,
                        Usuario = usuarioExistente,
                        DataCriacao = DateTime.Now,
                        ResponsavelCriacao = notificacao.ResponsavelCriacao,
                        DataEdicao = DateTime.Now,
                        ResponsavelEdicao = notificacao.ResponsavelEdicao,
                        IdOrganizacao = notificacao.IdOrganizacao
                    };

                    _organizacaoPessoaRepository.Save();
                    await _envioEmailService.EnvioNotificacao(notificacaoUsuario, entityPessoa.Nome);
                }
                else
                {
                    var usuario = _usuarioRepository.Find(x => x.Login == entityPessoa.Email).FirstOrDefault();
                    usuario.Login = pessoaEditar.Email;

                    usuarioOrganizacaoExistente.IdUsuario = usuarioExistente.Id;
                    usuarioOrganizacaoExistente.UsuarioPlataforma = pessoaEditar.eUsuario;
                    usuarioOrganizacaoExistente.Ativo = pessoaEditar.Status;
                    _organizacaoPessoaRepository.Update(usuarioOrganizacaoExistente);
                    _organizacaoPessoaRepository.Save();
                    _usuarioRepository.Update(usuario);
                    _usuarioRepository.Save();
                }
            }

            return retornoController;
        }
        //public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>> ConfiguraUsuario(Pessoa entityPessoa, Guid pessoaRequisitando, Guid idOrganizacao, bool eUsuario, bool eContaGoogle, string funcaoPrincipal, Guid idOrganizacaoRole, bool pessoaOrganizacaoAtivo)
        //{
        //    RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>();

        //    var usuarioExistente = _usuarioRepository.GetSingleOrDefault(x => x.Login == entityPessoa.Email);

        //    if (usuarioExistente == null)
        //    {
        //        usuarioExistente = await CriarUsuario(entityPessoa, eContaGoogle);
        //        if (usuarioExistente == null)
        //        {
        //            ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
        //            {
        //                Cabecalho = "Erro ao criar usuário",
        //                MensagemCurta = "Erro ao criar usuário",
        //                Detalhes = "Não foi possível criar usuário.",
        //                StatusCode = StatusCodes.Status204NoContent
        //            };

        //            retornoController.ExibicaoMensagem = exibicaoMensagem;
        //            return retornoController;
        //        }

        //        if (entityPessoa.Organizacoes != null && entityPessoa.Organizacoes.Any(x => x.IdOrganizacao == idOrganizacao))
        //        {
        //            var usuarioOrganizacao = entityPessoa.Organizacoes.SingleOrDefault(x => x.IdOrganizacao == idOrganizacao);
        //            usuarioOrganizacao.IdOrganizacao = idOrganizacao;
        //            usuarioOrganizacao.FuncaoPrincipal = funcaoPrincipal;
        //            usuarioOrganizacao.IdUsuario = usuarioExistente.Id;
        //            usuarioOrganizacao.IdPessoa = entityPessoa.Id;
        //            usuarioOrganizacao.UsuarioPlataforma = true;
        //            usuarioOrganizacao.Ativo = entityPessoa.Status;
        //            usuarioOrganizacao.IdOrganizacaoUsuarioRole = idOrganizacaoRole;
        //            _organizacaoPessoaRepository.Update(usuarioOrganizacao);
        //        }
        //        else
        //        {
        //            var usuarioOrganizacao = new OrganizacaoUsuario();
        //            usuarioOrganizacao.IdOrganizacao = idOrganizacao;
        //            usuarioOrganizacao.Id = Guid.NewGuid();
        //            usuarioOrganizacao.FuncaoPrincipal = funcaoPrincipal;
        //            usuarioOrganizacao.IdUsuario = usuarioExistente.Id;
        //            usuarioOrganizacao.IdPessoa = entityPessoa.Id;
        //            usuarioOrganizacao.UsuarioPlataforma = true;
        //            usuarioOrganizacao.Ativo = entityPessoa.Status;
        //            usuarioOrganizacao.DataCriacao = DateTime.Now;
        //            usuarioOrganizacao.ResponsavelCriacao = pessoaRequisitando;
        //            usuarioOrganizacao.IdOrganizacaoUsuarioRole = idOrganizacaoRole;
        //            _organizacaoPessoaRepository.Add(usuarioOrganizacao);
        //        }


        //        _organizacaoPessoaRepository.Save();

        //        //salvar os convites
        //        var convite = await CriarConvite(entityPessoa, pessoaRequisitando, idOrganizacao);

        //        if (convite == null)
        //        {
        //            ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
        //            {
        //                Cabecalho = "Erro ao criar convite",
        //                MensagemCurta = "Erro ao criar convite",
        //                Detalhes = "Não foi possível criar convite para criação de usuário.",
        //                StatusCode = StatusCodes.Status204NoContent
        //            };

        //            retornoController.ExibicaoMensagem = exibicaoMensagem;
        //            return retornoController;
        //        }

        //        _usuarioRepository.Save();
        //        //_organizacaoPessoaRepository.Save();

        //        //pegar link do convite
        //        var linkConvite = await _envioEmailService.GerarLink(convite.ConvitesHistorico.FirstOrDefault().Id,
        //            convite.ConvitesHistorico.FirstOrDefault().Token, "registro-pessoa");

        //        //emailService
        //        var envioConvite = await _envioEmailService.EnvioConvite(convite, linkConvite);

        //        convite.ConvitesHistorico.FirstOrDefault().FoiEnviado = envioConvite.Resposta;
        //        convite.ConvitesHistorico.FirstOrDefault().MensagemResultadoNotificacao = envioConvite.Mensagem;

        //        if (envioConvite.Resposta == false)
        //        {
        //            ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
        //            {
        //                Cabecalho = "Erro ao enviar convite",
        //                MensagemCurta = "Erro ao enviar convite",
        //                Detalhes = envioConvite.Mensagem,
        //                StatusCode = StatusCodes.Status500InternalServerError
        //            };

        //            retornoController.ExibicaoMensagem = exibicaoMensagem;

        //            return retornoController;
        //        }
        //    }
        //    else
        //    {
        //        var usuarioOrganizacaoExistente = await _organizacaoPessoaRepository.BuscarPorEmailPessoa(usuarioExistente.Login, idOrganizacao);
        //        if (usuarioOrganizacaoExistente == null)
        //        {
        //            var usuarioOrganizacao = new OrganizacaoUsuario();
        //            usuarioOrganizacao.IdOrganizacao = idOrganizacao;
        //            usuarioOrganizacao.IdUsuario = usuarioExistente.Id;
        //            usuarioOrganizacao.IdPessoa = entityPessoa.Id;
        //            usuarioOrganizacao.FuncaoPrincipal = funcaoPrincipal;
        //            usuarioOrganizacao.UsuarioPlataforma = eUsuario;
        //            usuarioOrganizacao.Ativo = entityPessoa.Status;
        //            usuarioOrganizacao.DataCriacao = DateTime.Now;
        //            usuarioOrganizacao.ResponsavelCriacao = pessoaRequisitando;
        //            usuarioOrganizacao.IdOrganizacaoUsuarioRole = idOrganizacaoRole;

        //            _organizacaoPessoaRepository.Add(usuarioOrganizacao);

        //            var organizacao = _organizacaoRepository.GetSingleOrDefault(x => x.Id == idOrganizacao);
        //            Notificacao notificacao = new Notificacao()
        //            {
        //                Titulo = "Você entrou em uma Organização",
        //                Mensagem = entityPessoa.Nome + " você entrou para a organização " + organizacao.Nome,
        //                Tipo = "Notificacao",
        //                ConfirmacaoLeitura = false,
        //                EnviadoPorEmail = false,
        //                DataCriacao = DateTime.Now,
        //                ResponsavelCriacao = pessoaRequisitando,
        //                DataEdicao = DateTime.Now,
        //                ResponsavelEdicao = pessoaRequisitando,
        //                IdOrganizacao = idOrganizacao
        //            };


        //            NotificacaoUsuario notificacaoUsuario = new NotificacaoUsuario()
        //            {
        //                Notificacao = notificacao,
        //                Usuario = usuarioExistente,
        //                DataCriacao = DateTime.Now,
        //                ResponsavelCriacao = notificacao.ResponsavelCriacao,
        //                DataEdicao = DateTime.Now,
        //                ResponsavelEdicao = notificacao.ResponsavelEdicao,
        //                IdOrganizacao = notificacao.IdOrganizacao
        //            };

        //            _organizacaoPessoaRepository.Save();
        //            await _envioEmailService.EnvioNotificacao(notificacaoUsuario, entityPessoa.Nome);
        //        }
        //        else
        //        {
        //            usuarioOrganizacaoExistente.IdUsuario = usuarioExistente.Id;
        //            usuarioOrganizacaoExistente.UsuarioPlataforma = eUsuario;
        //            usuarioOrganizacaoExistente.Ativo = pessoaOrganizacaoAtivo;
        //            _organizacaoPessoaRepository.Update(usuarioOrganizacaoExistente);
        //            _organizacaoPessoaRepository.Save();
        //        }
        //    }

        //    return retornoController;
        //}

        public async Task<Pessoa> ModelarPessoa(AdicionarPessoaViewModel adicionarPessoa, Guid idOrganizacao)
        {
            var time = await _unitOfWork.GetRepositoryAsync<Time>().GetOne(x => x.Id == adicionarPessoa.IdTime && x.IdOrganizacao == idOrganizacao);

            Pessoa pessoa = new Pessoa()
            {
                Id = Guid.NewGuid(),
                Nome = adicionarPessoa.Nome,
                Foto = adicionarPessoa.Foto,
                Telefone = adicionarPessoa.Telefone,
                Email = adicionarPessoa.Email,
                MiniBio = adicionarPessoa.MiniBio,
                Status = adicionarPessoa.Status,
                DataCriacao = DateTime.Now,
                ResponsavelCriacao = adicionarPessoa.ResponsavelCriacao,
                DataEdicao = DateTime.Now,
                ResponsavelEdicao = adicionarPessoa.ResponsavelEdicao,
                GoobeeAdmin = false
            };

            if (time != null)
            {
                TimePessoa timePessoa = new TimePessoa()
                {
                    IdPessoa = pessoa.Id,
                    IdTime = time.Id,
                    Status = true,
                    DataCriacao = DateTime.Now,
                    ResponsavelCriacao = adicionarPessoa.ResponsavelCriacao,
                    DataEdicao = DateTime.Now,
                    IdOrganizacao = idOrganizacao
                };

                pessoa.TimePessoas = new List<TimePessoa>();
                pessoa.TimePessoas.Add(timePessoa);
            }

            return pessoa;
        }

        public async Task<Convite> CriarConvite(Pessoa pessoa, Guid pessoaRequisitando, Guid idOrganizacao)
        {
            var mensagemNotificacao = "Olá, bem vindo ao Goobee!";

            Convite convite = new Convite
            {
                Nome = pessoa.Nome,
                IdOrganizacao = idOrganizacao,
                Email = pessoa.Email,
                PessoaCriada = pessoa,
                DataCriacao = DateTime.Now,
                DataEdicao = DateTime.Now,
                ResponsavelCriacao = pessoa.ResponsavelCriacao,
                Status = ConviteStatusEnum.Ativo
            };

            ConviteHistorico conviteHistorico = new ConviteHistorico
            {
                DataEnvio = DateTime.Now,
                DataExpiracao = await _tokenService.CalculaExpiracao(),
                Convite = convite,
                IdPessoaRequisita = pessoaRequisitando,
                MensagemNotificacao = mensagemNotificacao,
                Token = await _tokenService.GerarToken(),
                IdOrganizacao = idOrganizacao,
                FoiEnviado = false,
                MensagemResultadoNotificacao = null,
                DataCriacao = DateTime.Now,
                DataEdicao = DateTime.Now,
                ResponsavelCriacao = pessoa.ResponsavelCriacao
            };

            convite.ConvitesHistorico = new List<ConviteHistorico>();
            convite.ConvitesHistorico.Add(conviteHistorico);

            _conviteRepository.Add(convite);
            _conviteHistoricoRepository.Add(conviteHistorico);

            _conviteHistoricoRepository.Save();
            _conviteRepository.Save();

            var convitesAntigos = _conviteRepository.Find(x =>
                x.Email == convite.Email
                && x.Id != convite.Id
                && x.IdOrganizacao == idOrganizacao);

            foreach (var conviteAntigo in convitesAntigos)
            {
                conviteAntigo.Status = ConviteStatusEnum.Cancelado;
                _conviteRepository.Update(conviteAntigo);
            }

            try
            {
                _conviteHistoricoRepository.Save();
                _conviteRepository.Save();
            }
            catch (Exception e)
            {
                return null;
            }

            return convite;
        }

        public async Task<Usuario> CriarUsuario(Pessoa pessoa, bool eContaGoogle)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Id = Guid.NewGuid(),
                    Login = pessoa.Email,
                    Ativo = true,
                    DataCriacao = DateTime.Now,
                    DataEdicao = DateTime.Now,
                    ResponsavelCriacao = pessoa.ResponsavelCriacao,
                    ContaGoogle = eContaGoogle
                };

                _usuarioRepository.Add(usuario);

                return usuario;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //public async Task<bool> ConvidarNovamente(ConvidadarNovamenteViewModel convidarNovamente, Guid idOrganizacao)
        //{
        //    var convite = await _unitOfWork.GetRepositoryAsync<Convite>().GetOne(x => x.IdPessoaCriada == convidarNovamente.IdPessoa && x.IdOrganizacao == idOrganizacao);

        //    if (convite == null)
        //    {
        //        var pessoaConvidada = await _pessoaRepository.GetPorId(convidarNovamente.IdPessoa, idOrganizacao);
        //        convite = await CriarConvite(pessoaConvidada, convidarNovamente.IdResponsavel, idOrganizacao);
        //    }

        //    var mensagemNotificacao = "Olá, bem vindo ao Goobee!";

        //    ConviteHistorico conviteHistorico = new ConviteHistorico()
        //    {
        //        DataEnvio = DateTime.Now,
        //        IdOrganizacao = idOrganizacao,
        //        DataExpiracao = await _tokenService.CalculaExpiracao(),
        //        Convite = convite,
        //        IdPessoaRequisita = convidarNovamente.IdResponsavel,
        //        MensagemNotificacao = mensagemNotificacao,
        //        Token = await _tokenService.GerarToken(),
        //        FoiEnviado = false,
        //        MensagemResultadoNotificacao = null,
        //        DataCriacao = DateTime.Now,
        //        DataEdicao = DateTime.Now,
        //        ResponsavelCriacao = convidarNovamente.IdResponsavel
        //    };

        //    convite.ConvitesHistorico.Add(conviteHistorico);

        //    await _unitOfWork.GetRepositoryAsync<Convite>().Update(convite, convite);

        //    var convitesAntigos = await _unitOfWork.GetRepositoryAsync<Convite>().Get(x => x.Email == convite.Email && x.Id != convite.Id && x.IdOrganizacao == idOrganizacao);

        //    foreach (var conviteAntigo in convitesAntigos)
        //    {
        //        conviteAntigo.Status = ConviteStatusEnum.Cancelado;
        //    }

        //    try
        //    {
        //        _unitOfWork.Context.Set<Convite>().UpdateRange(convitesAntigos);
        //        _unitOfWork.Context.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }

        //    var linkConvite = await _envioEmailService.GerarLink(conviteHistorico.Id,
        //                                                    conviteHistorico.Token, "registro-pessoa");

        //    var envioConvite = await _envioEmailService.EnvioConvite(convite, linkConvite);

        //    conviteHistorico.FoiEnviado = envioConvite.Resposta;
        //    conviteHistorico.MensagemResultadoNotificacao = envioConvite.Mensagem;

        //    if (envioConvite.Resposta == false)
        //    {
        //        return false;
        //    }

        //    await _unitOfWork.SaveAsync();

        //    return true;
        //}

        public async Task<List<ListarPessoasViewModel>> ListarTodas(FiltrosListarPessoasViewModel filtros, Guid idOrganizacao, OrganizacaoUsuarioRoleEnum roleEnum)
        {
            Expression<Func<Pessoa, bool>> pbPessoa;

            if (roleEnum == OrganizacaoUsuarioRoleEnum.TeamMember)
            {
                pbPessoa = PredicateBuilder.False<Pessoa>();

                var timesPessoa = _pessoaRepository.PegarPessoaComTimePessoas(x => x.Id == filtros.IdPessoaLogada);

                foreach (var time in timesPessoa.TimePessoas)
                {
                    if (!time.Status)
                        continue;

                    pbPessoa = pbPessoa.Or(x => x.TimePessoas.Any(y => y.IdTime == time.IdTime && y.Status));
                }
            }
            else
            {
                pbPessoa = PredicateBuilder.True<Pessoa>();
            }

            pbPessoa = pbPessoa.And(x => x.Organizacoes.Any(y => y.IdPessoa == x.Id && y.IdOrganizacao == idOrganizacao));
            pbPessoa = pbPessoa.And(x => x.Status);

            if (filtros.NomeColaborador != string.Empty && filtros.NomeColaborador != null)
            {
                pbPessoa = pbPessoa.And(x => x.Organizacoes.Any(y => y.FuncaoPrincipal.ToUpper().Contains(filtros.NomeColaborador.ToUpper()))
                || x.Nome.ToUpper().Contains(filtros.NomeColaborador.ToUpper()));
            }

            if (filtros.IdTime != null)
            {
                pbPessoa = pbPessoa.And(x => x.TimePessoas.Any(y => y.IdTime == filtros.IdTime && y.Status));
            }

            if (filtros.IdGrupo != null)
            {
                pbPessoa = pbPessoa.And(x => x.TimePessoas.Any(y => y.Status && y.Time.TimeGrupos.Any(z => z.IdGrupo == filtros.IdGrupo)));
            }

            if (filtros.IdCliente != null)
            {
                pbPessoa = pbPessoa.And(x => x.PessoaClientes.Any(y => y.IdCliente == filtros.IdCliente));
            }

            if (filtros.IdResponsavel != null)
            {
                pbPessoa = pbPessoa.And(x => x.ResponsavelCriacao == filtros.IdResponsavel || x.ResponsavelEdicao == filtros.IdResponsavel);
            }

            if (filtros.Status != null)
            {
                pbPessoa = pbPessoa.And(x => x.Status == filtros.Status);
            }

            //if (filtros.Habilidade != string.Empty && filtros.Habilidade != null)
            //{
            //    pbPessoa = pbPessoa.And(x => x.PessoaHabilidades.Any(y => y.Habilidade.Nome.ToUpper().Contains(filtros.Habilidade.ToUpper())));
            //}

            List<ListarPessoasViewModel> listaPessoas = new List<ListarPessoasViewModel>();

            listaPessoas = _pessoaRepository.GetTopPessoas(predicate: pbPessoa, filtros.TerminaCom)
                .Select(x =>
                new ListarPessoasViewModel
                {
                    Nome = x.Nome,
                    Id = x.Id,
                    IdOrganizacao = x.Organizacoes.FirstOrDefault(y => y.IdOrganizacao == idOrganizacao).IdOrganizacao,
                    Status = x.Organizacoes.FirstOrDefault(y => y.IdOrganizacao == idOrganizacao).Ativo,
                    FuncaoPrincipal = x.Organizacoes.FirstOrDefault(y => y.IdOrganizacao == idOrganizacao)?.FuncaoPrincipal,
                    Email = x.Email,
                    Foto = x.Foto,
                    UltimoCliente = x.PessoaClientes.OrderByDescending(y => y.DataInicio).Select(z => z.Cliente.Nome).FirstOrDefault(),
                    //UltimoCheckpoint = x.PessoaCheckpoints.Where(y => y.Status == true)
                    //                                      .OrderByDescending(z => z.DataRealizacao)
                    //                                      .Select(w => w.DataRealizacao)
                    //                                      .FirstOrDefault(),
                    //ProximoCheckpoint = x.PessoaCheckpoints.Where(y => y.Status == false)
                    //                                      .OrderBy(z => z.DataAgendamento)
                    //                                      .Select(w => (DateTime?)w.DataAgendamento)
                    //                                      .FirstOrDefault(),
                    IdsTimes = x.TimePessoas.Where(x => x.Status && x.IdOrganizacao == idOrganizacao).Select(x => x.IdTime).ToList()
                }).Skip(filtros.ComecaCom).ToList();

            return listaPessoas;
        }

        //public async Task<PerfilViewModel> PegarPerfil(Guid id, Guid idOrganizacao)
        //{
        //    var pessoa = _pessoaRepository.PegarPerfilPessoa(x => x.Id == id && x.Organizacoes.Any(x => x.IdOrganizacao == idOrganizacao));

        //    PerfilViewModel perfil = new PerfilViewModel()
        //    {
        //        Foto = pessoa.Foto,
        //        Nome = pessoa.Nome,
        //        FuncaoPrincipal = pessoa.Organizacoes.FirstOrDefault(y => y.IdOrganizacao == idOrganizacao)?.FuncaoPrincipal,
        //        MiniBio = pessoa.MiniBio,
        //        UltimoCliente = pessoa.PessoaClientes.Where(x => x.IdOrganizacao == idOrganizacao)
        //                                             .OrderByDescending(x => x.DataInicio)
        //                                             .Select(x => x.Cliente.Nome)
        //                                             .FirstOrDefault(),
        //        QuantidadeVisitas = pessoa.PessoaCheckpoints.Count(x => x.Status && x.IdOrganizacao == idOrganizacao),
        //        MediaSentimentoColaborador = 0,
        //        UltimoCheckpoint = pessoa.PessoaCheckpoints.Where(x => x.Status == true && x.IdOrganizacao == idOrganizacao)
        //                                                  .OrderByDescending(x => x.DataRealizacao)
        //                                                  .Select(x => (DateTime?)x.DataRealizacao)
        //                                                  .FirstOrDefault(),
        //        ProximoCheckpoint = pessoa.PessoaCheckpoints.Where(x => x.Status == false && x.IdOrganizacao == idOrganizacao)
        //                                                  .OrderBy(x => x.DataAgendamento)
        //                                                  .Select(x => (DateTime?)x.DataAgendamento)
        //                                                  .FirstOrDefault(),
        //        SenhaCriada = pessoa.Convites.Any(x => x.Status == ConviteStatusEnum.Inativo)
        //    };

        //    List<SentimentoColaboradorEnum> listaSentimentos = new List<SentimentoColaboradorEnum>();

        //    foreach (var checkpoint in pessoa.PessoaCheckpoints)
        //    {
        //        if (checkpoint.SentimentoColaborador != 0)
        //        {
        //            listaSentimentos.Add(checkpoint.SentimentoColaborador);
        //        }
        //    }

        //    foreach (var sentimentoPessoa in pessoa.SentimentosPessoa)
        //    {
        //        if (sentimentoPessoa.Sentimento != 0)
        //        {
        //            listaSentimentos.Add(sentimentoPessoa.Sentimento);
        //        }
        //    }

        //    if (listaSentimentos.Count != 0)
        //    {
        //        perfil.MediaSentimentoColaborador = await _mediaSentimentoService.CalcularMediaSentimento(listaSentimentos.Count, listaSentimentos);
        //    }

        //    return perfil;
        //}

        public async Task<PerfilEditarViewModel> PegarEditarPerfil(Guid id, Guid idOrganizacao)
        {
            var pessoa = await _pessoaRepository.GetPorId(id, idOrganizacao);
            var organizacaoPessoa = pessoa.Organizacoes.FirstOrDefault(y => y.IdOrganizacao == idOrganizacao);
            PerfilEditarViewModel perfil = new PerfilEditarViewModel()
            {
                Id = pessoa.Id,
                Foto = pessoa.Foto,
                Nome = pessoa.Nome,
                FuncaoPrincipal = organizacaoPessoa == null ? "" : organizacaoPessoa.FuncaoPrincipal,
                Email = pessoa.Email,
                Telefone = pessoa.Telefone,
                MiniBio = pessoa.MiniBio,
                Status = organizacaoPessoa == null ? false : organizacaoPessoa.Ativo,
                eUsuario = organizacaoPessoa == null ? false : organizacaoPessoa.UsuarioPlataforma,
                NivelPermissao = organizacaoPessoa == null ? OrganizacaoUsuarioRoleEnum.TeamMember : organizacaoPessoa.OrganizacaoUsuarioRole.Role,
                eContaGoogle = organizacaoPessoa.Usuario == null ? false : organizacaoPessoa.Usuario.ContaGoogle
            };

            return perfil;
        }

        //public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>> EditarPerfil(PerfilEditarViewModel pessoaEditar, Guid idOrganizacao, OrganizacaoUsuarioRoleEnum roleEnum)
        //{
        //    RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>();

        //    if (roleEnum == OrganizacaoUsuarioRoleEnum.TeamMember)
        //    {
        //        if (pessoaEditar.Id != pessoaEditar.IdResponsavelEdicao)
        //        {
        //            ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
        //            {
        //                Cabecalho = "Erro ao editar pessoa",
        //                MensagemCurta = "Erro ao editar pessoa",
        //                Detalhes = "Sem permissão para edição de pessoa.",
        //                StatusCode = StatusCodes.Status400BadRequest
        //            };

        //            retornoController.ExibicaoMensagem = exibicaoMensagem;
        //            return retornoController;
        //        }
        //    }
        //    else if (roleEnum == OrganizacaoUsuarioRoleEnum.TeamLeader)
        //    {
        //        var leader = _pessoaRepository.PegarPessoaComTimePessoas(x => x.Id == pessoaEditar.IdResponsavelEdicao);
        //        var pessoaSendoEditada = _pessoaRepository.PegarPessoaComTimePessoas(x => x.Id == pessoaEditar.Id);

        //        bool permissaoEditar = false;

        //        foreach (var time in leader.TimePessoas)
        //        {
        //            if (pessoaSendoEditada.TimePessoas.Any(x => x.IdTime == time.IdTime))
        //            {
        //                permissaoEditar = true;
        //                break;
        //            }
        //        }

        //        if (!permissaoEditar)
        //        {
        //            ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
        //            {
        //                Cabecalho = "Erro ao editar pessoa",
        //                MensagemCurta = "Erro ao editar pessoa",
        //                Detalhes = "Sem permissão para edição de pessoa.",
        //                StatusCode = StatusCodes.Status400BadRequest
        //            };

        //            retornoController.ExibicaoMensagem = exibicaoMensagem;
        //            return retornoController;
        //        }

        //        if (!string.IsNullOrWhiteSpace(pessoaEditar.Senha))
        //        {
        //            if (pessoaEditar.Senha != pessoaEditar.ConfirmacaoSenha)
        //            {
        //                ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
        //                {
        //                    Cabecalho = "Erro ao editar pessoa",
        //                    MensagemCurta = "Erro ao editar pessoa",
        //                    Detalhes = "Senha e COnfirmação de Senha estão divergentes.",
        //                    StatusCode = StatusCodes.Status401Unauthorized
        //                };

        //                retornoController.ExibicaoMensagem = exibicaoMensagem;
        //                return retornoController;
        //            }
        //        }
        //    }

        //    var pessoa = _pessoaRepository.GetSingleOrDefault(x => x.Id == pessoaEditar.Id);
        //    //var emailExistente = _pessoaRepository.Find(x => x.Email == pessoaEditar.Email && x.Id != pessoa.Id);
        //    var emailExistenteSoEmail = _pessoaRepository.Find(x => x.Email == pessoaEditar.Email).FirstOrDefault();
        //    var usuarioExiste = _usuarioRepository.Find(x => x.Login == pessoaEditar.Email).FirstOrDefault();
        //    if (pessoaEditar.Email != pessoa.Email && (emailExistenteSoEmail != null || usuarioExiste != null))
        //    {
        //        ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
        //        {
        //            Cabecalho = "Erro ao editar pessoa",
        //            MensagemCurta = "Erro ao editar pessoa",
        //            Detalhes = "Já existe uma pessoa com esse e-mail.",
        //            StatusCode = StatusCodes.Status400BadRequest
        //        };

        //        retornoController.ExibicaoMensagem = exibicaoMensagem;
        //        return retornoController;
        //    }

        //    pessoa.Foto = pessoaEditar.Foto;
        //    pessoa.Nome = pessoaEditar.Nome;
        //    pessoa.Telefone = pessoaEditar.Telefone;
        //    pessoa.MiniBio = pessoaEditar.MiniBio;

        //    var organizacaoUsuario = pessoa.Organizacoes.FirstOrDefault(x => x.IdOrganizacao == idOrganizacao);

        //    Usuario usuario = null;
        //    if (organizacaoUsuario.Usuario != null)
        //    {
        //        usuario = _usuarioRepository.GetSingleOrDefault(x => x.Id == organizacaoUsuario.Usuario.Id);
        //    }

        //    if (organizacaoUsuario != null)
        //    {
        //        organizacaoUsuario.FuncaoPrincipal = pessoaEditar.FuncaoPrincipal;
        //        organizacaoUsuario.Ativo = pessoaEditar.Status;

        //        if (pessoa.Convites.Count > 0)
        //        {
        //            foreach (var convite in pessoa.Convites)
        //            {
        //                convite.Nome = pessoaEditar.Nome;
        //                convite.IdOrganizacao = idOrganizacao;
        //                convite.Email = pessoaEditar.Email;
        //                convite.DataEdicao = DateTime.Now;
        //                convite.ResponsavelEdicao = pessoaEditar.IdResponsavelEdicao;
        //            }
        //        }

        //        if (pessoaEditar.eUsuario)
        //        {
        //            Guid idOrganizacaoRole = Guid.Empty;
        //            if (pessoaEditar.NivelPermissao != null)
        //            {
        //                idOrganizacaoRole = _organizacaoRoleRepository.Find(x => x.Role == pessoaEditar.NivelPermissao).SingleOrDefault().Id;
        //                if (pessoaEditar.NivelPermissao == OrganizacaoUsuarioRoleEnum.GoobeeAdmin)
        //                {
        //                    pessoa.GoobeeAdmin = true;
        //                }
        //            }
        //            var entityPessoa = _mapper.Map<Te>(pessoa);
        //            var retorno = await ConfiguraUsuarioPerfil(entityPessoa, pessoaEditar, idOrganizacao, idOrganizacaoRole);
        //            pessoa.Email = pessoaEditar.Email;

        //            if (retorno.ExibicaoMensagem != null)
        //            {
        //                return retorno;
        //            }
        //        }
        //        else
        //        {
        //            organizacaoUsuario.UsuarioPlataforma = false;
        //            organizacaoUsuario.IdUsuario = null;
        //            _organizacaoPessoaRepository.Update(organizacaoUsuario);
        //            _organizacaoPessoaRepository.Save();
        //        }

        //        if (usuario != null)
        //        {
        //            if (pessoaEditar.eContaGoogle)
        //            {
        //                if (!usuario.ContaGoogle)
        //                {
        //                    usuario.ContaGoogle = pessoaEditar.eContaGoogle;
        //                    usuario.Senha = null;

        //                    _usuarioRepository.Update(usuario);
        //                    _usuarioRepository.Save();
        //                }
        //            }
        //            else
        //            {
        //                if (usuario.ContaGoogle)
        //                {
        //                    usuario.ContaGoogle = pessoaEditar.eContaGoogle;
        //                    usuario.Senha = CriptoHashSha256.GetSha256Hash(pessoaEditar.Senha);

        //                    _usuarioRepository.Update(usuario);
        //                    _usuarioRepository.Save();
        //                }
        //            }
        //        }
        //    }

        //    pessoa.DataEdicao = DateTime.Now;
        //    pessoa.ResponsavelEdicao = pessoaEditar.IdResponsavelEdicao;

        //    if (pessoaEditar.NivelPermissao != null && pessoaEditar.eUsuario)
        //    {
        //        if (roleEnum <= pessoa.Organizacoes.Where(x => x.IdOrganizacao == idOrganizacao).FirstOrDefault()?.OrganizacaoUsuarioRole.Role)
        //        {
        //            Guid idOrganizacaoRole = _organizacaoRoleRepository.Find(x => x.Role == pessoaEditar.NivelPermissao).SingleOrDefault().Id;

        //            List<OrganizacaoUsuario> organizacoesUsuario = new List<OrganizacaoUsuario>();
        //            organizacoesUsuario = _organizacaoPessoaRepository.Find(x => x.IdPessoa == pessoaEditar.Id && x.IdUsuario != null).ToList();

        //            if (organizacoesUsuario != null && organizacoesUsuario.Count() > 0)
        //            {
        //                //Se for alterada permissão para GoobeeAdmin - vira GoobeeAdmin em todas as organizações
        //                //Se ja for GoobeeAdmin e desceu nivel de permissão - é alterado para este nível em todas as organizações
        //                //Se nunca foi goobeeAdmin e mudou para outra permissão que não seja goobeeAdmin, só altera na organização corrente
        //                if (pessoaEditar.NivelPermissao != OrganizacaoUsuarioRoleEnum.GoobeeAdmin)
        //                {
        //                    pessoa.IdUltimaOrgAcessada = null;

        //                    if (!organizacoesUsuario.Any(x => x.OrganizacaoUsuarioRole.Role == OrganizacaoUsuarioRoleEnum.GoobeeAdmin))
        //                    {
        //                        organizacoesUsuario.RemoveAll(x => x.IdOrganizacao != idOrganizacao);
        //                    }
        //                    else
        //                    {
        //                        pessoa.GoobeeAdmin = false;
        //                    }
        //                }
        //                else
        //                {
        //                    pessoa.GoobeeAdmin = true;
        //                }

        //                foreach (var organizacao in organizacoesUsuario)
        //                {
        //                    organizacao.IdOrganizacaoUsuarioRole = idOrganizacaoRole;
        //                }

        //                _organizacaoPessoaRepository.UpdateRange(organizacoesUsuario);
        //                _organizacaoPessoaRepository.Save();
        //            }
        //            else //PESSOA QUE FOI CRIADA COMO GOOBEE ADMIN NA MÃO NO BANCO, NÃO TERÁ ORGANIZAÇÕES, LOGO O EDITAR SERA APENAS NA TABELA DE PESSOA
        //            {
        //                if (pessoaEditar.NivelPermissao != OrganizacaoUsuarioRoleEnum.GoobeeAdmin)
        //                {
        //                    pessoa.GoobeeAdmin = false;
        //                }
        //                else
        //                {
        //                    pessoa.GoobeeAdmin = true;
        //                }
        //            }
        //        }
        //    }

        //    _pessoaRepository.Update(pessoa);
        //    _pessoaRepository.Save();

        //    retornoController.Objeto = pessoa.Id;

        //    return retornoController;
        //}

        //public async Task<PegarTimePessoaViewModel> PegarTimePerfil(Guid idPerfil, Guid idPessoaLogada, Guid idOrganizacao)
        //{
        //    var pessoa = _pessoaRepository.PegarPessoaComTimePessoasTime(x => x.Id == idPerfil && x.Organizacoes.Any(x => x.IdOrganizacao == idOrganizacao));

        //    List<TimePerfilViewModel> timesPessoa = new List<TimePerfilViewModel>();
        //    foreach (var time in pessoa.TimePessoas)
        //    {
        //        if (time.Status && time.IdOrganizacao == idOrganizacao)
        //        {
        //            timesPessoa.Add(new TimePerfilViewModel()
        //            {
        //                Id = time.Time.Id,
        //                Nome = time.Time.Nome,
        //                Papel = time.Papel
        //            });
        //        }
        //    }

        //    IEnumerable<TimePerfilViewModel> todosTimesPessoaLogada = null;

        //    todosTimesPessoaLogada = _timeRepository.PegarTodosTimes(x => x.IdOrganizacao == idOrganizacao && x.TimePessoas
        //                                    .Any(x => x.IdOrganizacao == idOrganizacao && x.IdPessoa == idPessoaLogada))
        //                                    .Select(x => new TimePerfilViewModel()
        //                                    {
        //                                        Id = x.Id,
        //                                        Nome = x.Nome
        //                                    });

        //    //remove time que ja pertence a pessoa (um "distinct" diferenciado)
        //    todosTimesPessoaLogada = todosTimesPessoaLogada.Where(i => !timesPessoa.Any(x => x.Id == i.Id));

        //    PegarTimePessoaViewModel perfilTime = new PegarTimePessoaViewModel()
        //    {
        //        IdPessoa = pessoa.Id,
        //        TimesPessoa = timesPessoa.OrderBy(x => x.Nome).ToList(),
        //        TodosTimes = todosTimesPessoaLogada.OrderBy(x => x.Nome).ToList()
        //    };

        //    return perfilTime;
        //}

        public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, string>> EditarTimePerfil(EditarTimePerfilViewModel timesPessoa, Guid idOrganizacao)
        {
            RetornoControllerViewModel<ExibicaoMensagemViewModel, string> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, string>();

            try
            {
                foreach (var timeAntigo in timesPessoa.TimesAntigos)
                {
                    if (!timesPessoa.TimesNovos.Any(x => x.Id == timeAntigo.Id))
                    {
                        var entidade = await _unitOfWork.GetRepositoryAsync<TimePessoa>().GetOne(x => x.IdTime == timeAntigo.Id && x.IdPessoa == timesPessoa.IdPessoa && x.IdOrganizacao == idOrganizacao);
                        entidade.Status = false;
                        await _unitOfWork.GetRepositoryAsync<TimePessoa>().Update(entidade, entidade);
                    }
                }

                foreach (var timeNovo in timesPessoa.TimesNovos)
                {
                    if (!timesPessoa.TimesAntigos.Any(x => x.Id == timeNovo.Id))
                    {
                        TimePessoa timePessoa = new TimePessoa()
                        {
                            IdTime = timeNovo.Id,
                            IdOrganizacao = idOrganizacao,
                            IdPessoa = timesPessoa.IdPessoa,
                            Papel = timeNovo.Papel,
                            DataCriacao = DateTime.Now,
                            DataEdicao = DateTime.Now,
                            Status = true
                        };

                        await _unitOfWork.GetRepositoryAsync<TimePessoa>().Insert(timePessoa);
                    }
                    else
                    {
                        var time = timesPessoa.TimesAntigos.Where(x => x.Id == timeNovo.Id).FirstOrDefault();
                        if (time != null && timeNovo.Papel != time.Papel)
                        {
                            var timePessoa = await _unitOfWork.GetRepositoryAsync<TimePessoa>().GetOne(x => x.IdTime == timeNovo.Id && x.IdPessoa == timesPessoa.IdPessoa && x.IdOrganizacao == idOrganizacao);
                            timePessoa.IdOrganizacao = idOrganizacao;
                            timePessoa.Papel = timeNovo.Papel;
                            timePessoa.DataEdicao = DateTime.Now;

                            await _unitOfWork.GetRepositoryAsync<TimePessoa>().Update(timePessoa, timePessoa);
                        }
                    }
                }

                await _unitOfWork.SaveAsync();

                retornoController.Objeto = "Alterações realizadas com sucesso";

                return retornoController;
            }
            catch (Exception e)
            {
                retornoController.ExibicaoMensagem = new ExibicaoMensagemViewModel
                {
                    Cabecalho = "Ocurreu um erro",
                    MensagemCurta = "Ocurreu um erro",
                    Detalhes = e.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return retornoController;
            }
        }

        public async Task<PegarClientePessoaViewModel> PegarClientePerfil(Guid id, Guid idOrganizacao)
        {
            var pessoa = await _pessoaRepository.GetPorId(id, idOrganizacao);

            List<ClientePerfilViewModel> clientesPessoa = new List<ClientePerfilViewModel>();
            foreach (var cliente in pessoa.PessoaClientes)
            {
                if (cliente.Status)
                {
                    clientesPessoa.Add(new ClientePerfilViewModel()
                    {
                        Id = cliente.Cliente.Id,
                        Nome = cliente.Cliente.Nome,
                        DataInicio = cliente.DataInicio,
                        DataFim = cliente.DataFim
                    });
                }
            }

            var clientes = await _unitOfWork.GetRepositoryAsync<Cliente>().Get(x => x.IdOrganizacao == idOrganizacao);

            List<ClientePerfilViewModel> todosClientes = new List<ClientePerfilViewModel>();
            foreach (var cliente in clientes)
            {
                todosClientes.Add(new ClientePerfilViewModel()
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome
                });
            }

            PegarClientePessoaViewModel perfilCliente = new PegarClientePessoaViewModel()
            {
                IdPessoa = pessoa.Id,
                ClientesPessoa = clientesPessoa.OrderBy(x => x.Nome).ToList(),
                TodosClientes = todosClientes.OrderBy(x => x.Nome).ToList()
            };

            return perfilCliente;
        }

        public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, string>> EditarClientePerfil(EditarClientePerfilViewModel clientesPessoa, Guid idOrganizacao)
        {
            RetornoControllerViewModel<ExibicaoMensagemViewModel, string> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, string>();

            try
            {
                foreach (var clienteAntigo in clientesPessoa.ClientesAntigos)
                {
                    if (!clientesPessoa.ClientesNovos.Any(x => x.Id == clienteAntigo.Id))
                    {
                        var entidade = await _unitOfWork.GetRepositoryAsync<PessoaCliente>().GetOne(x =>
                            x.IdCliente == clienteAntigo.Id && x.IdPessoa == clientesPessoa.IdPessoa &&
                            x.IdOrganizacao == idOrganizacao);

                        entidade.Status = false;
                        await _unitOfWork.GetRepositoryAsync<PessoaCliente>().Update(entidade, entidade);
                    }
                }

                foreach (var clienteNovo in clientesPessoa.ClientesNovos)
                {
                    if (!clientesPessoa.ClientesAntigos.Any(x => x.Id == clienteNovo.Id))
                    {
                        PessoaCliente clientePessoa = new PessoaCliente()
                        {
                            IdCliente = clienteNovo.Id,
                            IdOrganizacao = idOrganizacao,
                            IdPessoa = clientesPessoa.IdPessoa,
                            DataInicio = clienteNovo.DataInicio,
                            DataFim = clienteNovo.DataFim,
                            DataCriacao = DateTime.Now,
                            DataEdicao = DateTime.Now
                        };

                        await _unitOfWork.GetRepositoryAsync<PessoaCliente>().Insert(clientePessoa);
                    }
                    else
                    {
                        var cliente = clientesPessoa.ClientesAntigos.Where(x => x.Id == clienteNovo.Id).FirstOrDefault();
                        if (cliente != null && (clienteNovo.DataInicio != cliente.DataInicio || clienteNovo.DataFim != cliente.DataFim))
                        {
                            var clientePessoa = await _unitOfWork.GetRepositoryAsync<PessoaCliente>().GetOne(x => x.IdCliente == clienteNovo.Id && x.IdPessoa == clientesPessoa.IdPessoa);

                            clientePessoa.DataInicio = clienteNovo.DataInicio;
                            clientePessoa.DataFim = clientePessoa.DataFim;
                            clientePessoa.DataEdicao = DateTime.Now;
                            clientePessoa.IdOrganizacao = idOrganizacao;

                            await _unitOfWork.GetRepositoryAsync<PessoaCliente>().Update(clientePessoa, clientePessoa);
                        }
                    }
                }

                await _unitOfWork.SaveAsync();

                retornoController.Objeto = "Alterações realizadas com sucesso";

                return retornoController;
            }
            catch (Exception e)
            {
                retornoController.ExibicaoMensagem = new ExibicaoMensagemViewModel
                {
                    Cabecalho = "Ocurreu um erro",
                    MensagemCurta = "Ocurreu um erro",
                    Detalhes = e.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return retornoController;
            }
        }

        public async Task<List<ClientePerfilViewModel>> HistoricoClientesPessoa(Guid id, Guid idOrganizacao)
        {
            var pessoa = await _pessoaRepository.GetPorId(id, idOrganizacao);

            List<ClientePerfilViewModel> clientesPessoa = new List<ClientePerfilViewModel>();
            foreach (var cliente in pessoa.PessoaClientes)
            {
                clientesPessoa.Add(new ClientePerfilViewModel()
                {
                    Id = cliente.Cliente.Id,
                    Nome = cliente.Cliente.Nome,
                    DataInicio = cliente.DataInicio,
                    DataFim = cliente.DataFim
                });
            }

            return clientesPessoa.OrderByDescending(x => x.DataInicio).ToList();
        }

        //public async Task<RetornoControllerViewModel<AcaoViewModel, Guid>> AdicionaAcao(AcaoViewModel acao, Guid idOrganizacao)
        //{
        //    var novaAcao = new Acao();
        //    novaAcao.IdOrganizacao = idOrganizacao;
        //    novaAcao.NomeAcao = acao.NomeAcao;
        //    novaAcao.DetalheAcao = acao.DetalheAcao;
        //    novaAcao.Data = acao.Data;
        //    novaAcao.IdPessoaCriacao = acao.IdPessoaCriacao;
        //    novaAcao.IdResponsavel = acao.IdResponsavel;
        //    novaAcao.Status = acao.Status;
        //    novaAcao.DataCriacao = DateTime.Now;
        //    novaAcao.ResponsavelCriacao = acao.IdResponsavel.GetValueOrDefault();

        //    await _unitOfWork.GetRepositoryAsync<Acao>().Insert(novaAcao);
        //    await _unitOfWork.SaveAsync();

        //    RetornoControllerViewModel<AcaoViewModel, Guid> retornoController = new RetornoControllerViewModel<AcaoViewModel, Guid>();
        //    retornoController.Objeto = novaAcao.Id;

        //    return retornoController;
        //}

        //public async Task<IEnumerable<ListaAcaoColaboradorViewModel>> ListarAcoes(Guid id, Guid idOrganizacao)
        //{
        //    var listaAcoes = await _unitOfWork.GetRepositoryAsync<Acao>().Get(x => x.IdPessoaCriacao == id && x.IdOrganizacao == idOrganizacao);
        //    return listaAcoes.Select(
        //        x => new ListaAcaoColaboradorViewModel
        //        {
        //            Id = x.Id,
        //            Data = x.Data,
        //            DetalheAcao = x.DetalheAcao,
        //            IdPessoaCriacao = x.IdPessoaCriacao,
        //            IdResponsavel = x.IdResponsavel,
        //            NomeAcao = x.NomeAcao,
        //            Status = x.Status,
        //            NomePessoaCriacao = x.PessoaCriacao.Nome,
        //            NomeResponsavel = x.Responsavel.Nome
        //        }).OrderByDescending(x => x.Data).ToList();
        //}

        //public async Task<ListaAcaoColaboradorViewModel> PegarAcaoColaborador(Guid idColaborador, Guid idAcao, Guid idOrganizacao)
        //{
        //    var acao = await _unitOfWork.GetRepositoryAsync<Acao>().GetOne(x => x.IdPessoaCriacao == idColaborador && x.Id == idAcao && x.IdOrganizacao == idOrganizacao);

        //    if (acao != null)
        //    {
        //        var acaoModelo = new ListaAcaoColaboradorViewModel()
        //        {
        //            Id = acao.Id,
        //            IdResponsavel = acao.IdResponsavel,
        //            DetalheAcao = acao.DetalheAcao,
        //            IdPessoaCriacao = acao.IdPessoaCriacao,
        //            NomeAcao = acao.NomeAcao,
        //            NomePessoaCriacao = acao.PessoaCriacao.Nome,
        //            NomeResponsavel = acao.Responsavel.Nome,
        //            Data = acao.Data,
        //            Status = acao.Status
        //        };

        //        return acaoModelo;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public async Task<Guid> EditarAcaoColaborador(ListaAcaoColaboradorViewModel acao, Guid idOrganizacao)
        //{
        //    try
        //    {
        //        var acaoModelo = await _unitOfWork.GetRepositoryAsync<Acao>().GetOne(x =>
        //            x.Id == acao.Id && x.PessoaCriacao.Id == acao.IdPessoaCriacao && x.IdOrganizacao == idOrganizacao);

        //        acaoModelo.IdResponsavel = acao.IdResponsavel;
        //        acaoModelo.NomeAcao = acao.NomeAcao;
        //        acaoModelo.Data = acao.Data;
        //        acaoModelo.DetalheAcao = acao.DetalheAcao;
        //        acaoModelo.Status = acao.Status;
        //        acaoModelo.IdOrganizacao = idOrganizacao;
        //        acaoModelo.DataEdicao = DateTime.Now;
        //        acaoModelo.ResponsavelEdicao = acao.IdResponsavel.GetValueOrDefault();

        //        await _unitOfWork.GetRepositoryAsync<Acao>().Update(acaoModelo.Id, acaoModelo);
        //        await _unitOfWork.SaveAsync();

        //        return acaoModelo.Id;
        //    }
        //    catch (Exception error)
        //    {
        //        return Guid.Empty;
        //    }
        //}

        //public async Task<Guid> DeletarAcaoColaborador(Guid id)
        //{
        //    try
        //    {
        //        await _unitOfWork.GetRepositoryAsync<Acao>().Delete(id);
        //        await _unitOfWork.SaveAsync();

        //        return id;
        //    }
        //    catch (Exception error)
        //    {
        //        return Guid.Empty;
        //    }
        //}

        //public async Task<List<TimeMembroViewModel>> ListaMembrosMesmoTime(Guid id, Guid idOrganizacao)
        //{
        //    List<TimeMembroViewModel> listaDeMembros = new List<TimeMembroViewModel>();
        //    var x = await _unitOfWork.GetRepositoryAsync<TimePessoa>().Get(y => y.IdTime == id && y.IdOrganizacao == idOrganizacao
        //    && y.Pessoa.Organizacoes.Where(x => x.IdPessoa == y.IdPessoa && x.IdOrganizacao == idOrganizacao).FirstOrDefault().Pessoa.Status);

        //    foreach (var item in x)
        //    {
        //        listaDeMembros.AddRange(x.Select(w => new TimeMembroViewModel()
        //        {
        //            IdMembro = w.IdPessoa,
        //            NomeMembro = w.Pessoa.Nome
        //        }).ToList());
        //    }

        //    return listaDeMembros.GroupBy(y => y.IdMembro).Select(w => w.First()).OrderBy(x => x.NomeMembro).ToList();
        //}

        public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>> AdicionarPersonalMapping(AdicionarPersonalMappingViewModel personalMapping, Guid idOrganizacao, OrganizacaoUsuarioRoleEnum roleEnum)
        {
            var pessoa = _pessoaRepository.GetSingleOrDefault(x => x.Id == personalMapping.IdPessoa);
            RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>();

            if (pessoa == null)
            {
                ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                {
                    Cabecalho = "Ocorreu um erro",
                    MensagemCurta = "Ocorreu um erro",
                    Detalhes = "Id da pessoa inválido.",
                    StatusCode = StatusCodes.Status400BadRequest
                };

                retornoController.ExibicaoMensagem = exibicaoMensagem;
                return retornoController;
            }

            if (roleEnum == OrganizacaoUsuarioRoleEnum.TeamMember && personalMapping.IdPessoa != personalMapping.IdResponsavel)
            {
                ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                {
                    Cabecalho = "Ocorreu um erro",
                    MensagemCurta = "Ocorreu um erro",
                    Detalhes = "Pessoa pode adicionar somente para si mesmo.",
                    StatusCode = StatusCodes.Status400BadRequest
                };

                retornoController.ExibicaoMensagem = exibicaoMensagem;
                return retornoController;
            }

            List<PersonalMappingItem> personalMappingItens = new List<PersonalMappingItem>();
            foreach (var item in personalMapping.Itens)
            {
                PersonalMappingItem personalMappingItem = new PersonalMappingItem()
                {
                    Item = item,
                    DataCriacao = DateTime.Now,
                    DataEdicao = DateTime.Now,
                    ResponsavelCriacao = personalMapping.IdResponsavel,
                    ResponsavelEdicao = personalMapping.IdResponsavel,
                    IdOrganizacao = idOrganizacao
                };

                personalMappingItens.Add(personalMappingItem);
            }

            PersonalMappingTitulo personalMappingTitulo = new PersonalMappingTitulo()
            {
                Titulo = personalMapping.Titulo,
                Pessoa = pessoa,
                DataCriacao = DateTime.Now,
                DataEdicao = DateTime.Now,
                ResponsavelCriacao = personalMapping.IdResponsavel,
                PersonalMappingItens = personalMappingItens,
                IdOrganizacao = idOrganizacao
            };

            await _unitOfWork.GetRepositoryAsync<PersonalMappingTitulo>().Insert(personalMappingTitulo);

            await _unitOfWork.SaveAsync();

            retornoController.Objeto = personalMappingTitulo.Id;

            return retornoController;
        }

        public async Task<List<PegarPersonalMappingViewModel>> PegarPersonalMapping(Guid id, Guid idOrganizacao)
        {
            IEnumerable<PegarPersonalMappingViewModel> personalMappings = (await _unitOfWork
                    .GetRepositoryAsync<PersonalMappingTitulo>()
                    .Get(x => x.IdPessoa == id))
                .Select(x => new PegarPersonalMappingViewModel
                {
                    IdTitulo = x.Id,
                    Titulo = x.Titulo,
                    Itens = x.PersonalMappingItens.Select(y => new PegarPersonalMappingItemViewModel
                    {
                        IdItem = y.Id,
                        NomeItem = y.Item
                    }).OrderBy(x => x.NomeItem).ToList()
                }).OrderBy(x => x.Titulo);

            return personalMappings.ToList();
        }

        //public async Task<IEnumerable<ResponsaveisComboBoxViewModel>> PegarResponsaveisComboBox(Guid idOrganizacao)
        //{
        //    var responsaveisComboBox = _pessoaRepository.PegarTodasPessoas(idOrganizacao)
        //        .Select(x => new ResponsaveisComboBoxViewModel()
        //        {
        //            Id = x.Id,
        //            Nome = x.Nome
        //        }).OrderBy(x => x.Nome).ToList();

        //    return responsaveisComboBox;
        //}

        public async Task<List<PessoasAtivasViewModel>> PegarPessoasUsuarioNaoInclusivo(Guid idPessoa, Guid idOrganizacao)
        {
            var pessoasAtivas = _pessoaRepository.PegarTodasPessoasNaoInclusivo(idPessoa, idOrganizacao);

            List<PessoasAtivasViewModel> pessoas = new List<PessoasAtivasViewModel>();
            foreach (var elem in pessoasAtivas)
            {
                var pessoa = new PessoasAtivasViewModel();
                pessoa.Id = elem.Id;
                pessoa.Nome = elem.Nome;
                pessoa.Email = elem.Email;
                pessoa.Status = elem.Status;

                pessoas.Add(pessoa);
            }

            return pessoas.OrderBy(x => x.Nome).ToList();
        }

        public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, string>> EditarPersonalMapping(EditarPersonalMappingViewModel personalMapping, Guid idOrganizacao, OrganizacaoUsuarioRoleEnum roleEnum)
        {
            RetornoControllerViewModel<ExibicaoMensagemViewModel, string> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, string>();

            try
            {
                var pessoa = _pessoaRepository.GetSingleOrDefault(x => x.Id == personalMapping.IdPessoa);

                if (pessoa == null)
                {
                    ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                    {
                        Cabecalho = "Ocorreu um erro",
                        MensagemCurta = "Ocorreu um erro",
                        Detalhes = "Id da pessoa inválido.",
                        StatusCode = StatusCodes.Status400BadRequest
                    };

                    retornoController.ExibicaoMensagem = exibicaoMensagem;
                    return retornoController;
                }

                if (roleEnum == OrganizacaoUsuarioRoleEnum.TeamMember && personalMapping.IdPessoa != personalMapping.IdResponsavel)
                {
                    ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                    {
                        Cabecalho = "Ocorreu um erro",
                        MensagemCurta = "Ocorreu um erro",
                        Detalhes = "Pessoa pode editar somente para si mesmo.",
                        StatusCode = StatusCodes.Status400BadRequest
                    };

                    retornoController.ExibicaoMensagem = exibicaoMensagem;
                    return retornoController;
                }

                var personalMappingTitulo = await _unitOfWork.GetRepositoryAsync<PersonalMappingTitulo>().GetOne(x => x.Id == personalMapping.IdTitulo && x.IdOrganizacao == idOrganizacao);

                personalMappingTitulo.Titulo = personalMapping.Titulo;
                personalMappingTitulo.DataEdicao = DateTime.Now;
                personalMappingTitulo.ResponsavelEdicao = personalMapping.IdResponsavel;

                var itensCadastrados = personalMappingTitulo.PersonalMappingItens.ToList();

                foreach (var item in personalMapping.Itens)
                {
                    if (item.IdItem == null)
                    {
                        PersonalMappingItem personalMappingItem = new PersonalMappingItem()
                        {
                            IdPersonalMappingTitulo = personalMapping.IdTitulo,
                            Item = item.NomeItem,
                            DataCriacao = DateTime.Now,
                            DataEdicao = DateTime.Now,
                            ResponsavelCriacao = personalMapping.IdResponsavel,
                            ResponsavelEdicao = personalMapping.IdResponsavel,
                            IdOrganizacao = idOrganizacao
                        };

                        await _unitOfWork.GetRepositoryAsync<PersonalMappingItem>().Insert(personalMappingItem);
                    }
                    else
                    {
                        itensCadastrados.RemoveAll(x => x.Id == item.IdItem);
                    }

                }

                foreach (var itemCadastrado in itensCadastrados)
                {
                    await _unitOfWork.GetRepositoryAsync<PersonalMappingItem>().Delete(itemCadastrado.Id);
                }

                await _unitOfWork.SaveAsync();

                retornoController.Objeto = "Alterações realizadas com sucesso";

                return retornoController;
            }
            catch (Exception e)
            {
                retornoController.ExibicaoMensagem = new ExibicaoMensagemViewModel
                {
                    Cabecalho = "Ocurreu um erro",
                    MensagemCurta = "Ocurreu um erro",
                    Detalhes = e.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return retornoController;
            }
        }

        public async Task<bool> DeletarPersonalMapping(Guid Id)
        {
            try
            {
                await _unitOfWork.GetRepositoryAsync<PersonalMappingTitulo>().Delete(Id);
                await _unitOfWork.SaveAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //public async Task<List<Guid>> AdicionarHabilidade(AdicionarHabilidadeViewModel adicionarHabilidade, Guid idOrganizacao)
        //{
        //    try
        //    {
        //        if (adicionarHabilidade.IdHabilidade == null)
        //        {
        //            PessoaHabilidade pessoaHabilidade;

        //            var habilidades = await _unitOfWork.GetRepositoryAsync<Habilidade>().Get(x => x.IdOrganizacao == idOrganizacao);

        //            if (habilidades.Any(x => x.Nome.ToUpper() == adicionarHabilidade.NomeHabilidade.ToUpper()))
        //            {
        //                var hab = habilidades.Where(x => x.Nome.ToUpper() == adicionarHabilidade.NomeHabilidade.ToUpper()).FirstOrDefault();

        //                pessoaHabilidade = new PessoaHabilidade()
        //                {
        //                    IdPessoa = adicionarHabilidade.IdPessoa,
        //                    IdHabilidade = hab.Id,
        //                    DataCriacao = DateTime.Now,
        //                    ResponsavelCriacao = adicionarHabilidade.IdResponsavelCriacao,
        //                    IdOrganizacao = idOrganizacao
        //                };

        //                await _unitOfWork.GetRepositoryAsync<PessoaHabilidade>().Insert(pessoaHabilidade);

        //                await _unitOfWork.SaveAsync();

        //                return new List<Guid>() { { pessoaHabilidade.IdPessoa }, { pessoaHabilidade.IdHabilidade } };
        //            }

        //            Habilidade habilidade = new Habilidade()
        //            {
        //                Nome = adicionarHabilidade.NomeHabilidade,
        //                DataCriacao = DateTime.Now,
        //                ResponsavelCriacao = adicionarHabilidade.IdResponsavelCriacao,
        //                IdOrganizacao = idOrganizacao
        //            };

        //            pessoaHabilidade = new PessoaHabilidade()
        //            {
        //                IdPessoa = adicionarHabilidade.IdPessoa,
        //                Habilidade = habilidade,
        //                DataCriacao = DateTime.Now,
        //                ResponsavelCriacao = adicionarHabilidade.IdResponsavelCriacao,
        //                IdOrganizacao = idOrganizacao
        //            };

        //            await _unitOfWork.GetRepositoryAsync<PessoaHabilidade>().Insert(pessoaHabilidade);

        //            await _unitOfWork.SaveAsync();

        //            return new List<Guid>() { { pessoaHabilidade.IdPessoa }, { pessoaHabilidade.IdHabilidade } };
        //        }
        //        else
        //        {
        //            PessoaHabilidade pessoaHabilidade = new PessoaHabilidade()
        //            {
        //                IdPessoa = adicionarHabilidade.IdPessoa,
        //                IdHabilidade = adicionarHabilidade.IdHabilidade.Value,
        //                DataCriacao = DateTime.Now,
        //                ResponsavelCriacao = adicionarHabilidade.IdResponsavelCriacao,
        //                IdOrganizacao = idOrganizacao
        //            };

        //            await _unitOfWork.GetRepositoryAsync<PessoaHabilidade>().Insert(pessoaHabilidade);

        //            await _unitOfWork.SaveAsync();

        //            return new List<Guid>() { { pessoaHabilidade.IdPessoa }, { pessoaHabilidade.IdHabilidade } };
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public async Task<bool> RemoverHabilidade(RemoverHabilidadeViewModel removerHabilidade, Guid idOrganizacao)
        //{
        //    try
        //    {
        //        var pessoaHabilidade = await _unitOfWork.GetRepositoryAsync<PessoaHabilidade>().GetOne(x => x.IdPessoa == removerHabilidade.IdPessoa
        //                                                                        && x.IdHabilidade == removerHabilidade.IdHabilidade && x.IdOrganizacao == idOrganizacao);

        //        _unitOfWork.GetRepositoryAsync<PessoaHabilidade>().Delete(pessoaHabilidade);
        //        await _unitOfWork.SaveAsync();

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public async Task<PegarMotivadoresViewModel> PegarMotivadores(Guid idPessoa, Guid idOrganizacao)
        //{
        //    PegarMotivadoresViewModel motivadores = new PegarMotivadoresViewModel();
        //    motivadores.IdPessoa = idPessoa;
        //    motivadores.Motivadores = _pessoaMotivadoresRepository.Find(x => x.IdPessoa == idPessoa).Select(x =>
        //            new PegarMotivadorViewModel()
        //            {
        //                Id = x.IdMotivador,
        //                Nome = x.Motivador.Nome,
        //                Indice = x.Indice
        //            })
        //        .OrderBy(x => x.Indice)
        //        .ToList();

        //    return motivadores;
        //}

        //public async Task<Guid> AdicionarMotivadores(AdicionarMotivadoresViewModel adicionarMotivadores, Guid idOrganizacao, OrganizacaoUsuarioRoleEnum roleEnum)
        //{
        //    try
        //    {
        //        if (roleEnum == OrganizacaoUsuarioRoleEnum.TeamMember && adicionarMotivadores.IdPessoa != adicionarMotivadores.IdResponsavelCriacao)
        //        {
        //            return Guid.Empty;
        //        }

        //        var motivadores = _motivadorRepository.GetAll().OrderBy(x => x.Nome);

        //        int indice = 1;

        //        foreach (var motivador in motivadores)
        //        {
        //            PessoaMotivador pessoaMotivador = new PessoaMotivador()
        //            {
        //                IdMotivador = motivador.Id,
        //                IdPessoa = adicionarMotivadores.IdPessoa,
        //                Indice = indice,
        //                DataCriacao = DateTime.Now,
        //                ResponsavelCriacao = adicionarMotivadores.IdResponsavelCriacao,
        //                IdOrganizacao = idOrganizacao
        //            };

        //            motivador.PessoaMotivadores.Add(pessoaMotivador);

        //            indice++;
        //        }

        //        _motivadorRepository.UpdateRange(motivadores);
        //        _motivadorRepository.Save();

        //        return adicionarMotivadores.IdPessoa;
        //    }
        //    catch
        //    {
        //        return Guid.Empty;
        //    }
        //}

        //public async Task<bool> EditarMotivadores(EditarMotivadoresViewModel motivadoresEditados, Guid idOrganizacao, OrganizacaoUsuarioRoleEnum roleEnum)
        //{
        //    try
        //    {
        //        if (roleEnum == OrganizacaoUsuarioRoleEnum.TeamMember && motivadoresEditados.IdPessoa != motivadoresEditados.IdResponsavelEdicao)
        //        {
        //            return false;
        //        }

        //        var motivadores = await _unitOfWork.GetRepositoryAsync<PessoaMotivador>().Get(x => x.IdPessoa == motivadoresEditados.IdPessoa);

        //        foreach (var motivadorEditado in motivadoresEditados.MotivadoresEditados)
        //        {
        //            var motivador = motivadores.Where(x => x.IdMotivador == motivadorEditado.IdMotivador).FirstOrDefault();

        //            if (motivador == null)
        //            {
        //                return false;
        //            }

        //            if (motivador.Indice != motivadorEditado.Indice)
        //            {

        //                motivador.Indice = motivadorEditado.Indice;
        //                motivador.DataEdicao = DateTime.Now;
        //                motivador.ResponsavelEdicao = motivadoresEditados.IdResponsavelEdicao;

        //                await _unitOfWork.GetRepositoryAsync<PessoaMotivador>().Update(motivador, motivador);
        //            }
        //        }

        //        await _unitOfWork.SaveAsync();

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task<bool> AtualizarFoto(Guid id, string urlImagem, Guid idOrganizacao)
        {
            try
            {
                var pessoa = await _unitOfWork.GetRepositoryAsync<Pessoa>().GetOne(x => x.Id == id && x.Organizacoes.Any(x => x.IdOrganizacao == idOrganizacao));
                if (pessoa != null)
                {
                    pessoa.Foto = urlImagem;
                    await _unitOfWork.GetRepositoryAsync<Pessoa>().Update(pessoa.Id, pessoa);
                    await _unitOfWork.SaveAsync();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}