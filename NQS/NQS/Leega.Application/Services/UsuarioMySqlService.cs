using Leega.Application.Interfaces;
using Leega.Application.ViewModels;
using Leega.DataMySql.Entity;
using Leega.DataMySql.Repositories.Interfaces;
using Leega.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Application.Services
{
    public class UsuarioMySqlService : BaseMySqlService, IUsuarioMySqlService
    {
        private readonly IUsuarioMySqlRepository _usuarioMySqlRepository;
        private readonly IPessoaMySqlRepository _pessoaMySqlRepository;

        public UsuarioMySqlService(IUsuarioMySqlRepository usuarioMySqlRepository,
            IPessoaMySqlRepository pessoaMySqlRepository)
        {
            _usuarioMySqlRepository = usuarioMySqlRepository;
            _pessoaMySqlRepository = pessoaMySqlRepository;
        }

        public void Adicionar(UsuarioMySqlViewModel obj, bool eContaGoogle)
        {
            obj.Senha = string.IsNullOrWhiteSpace(obj.Senha) ? Guid.NewGuid().ToString().Substring(0, 5) : obj.Senha;

            _usuarioMySqlRepository.Adicionar(new UsuarioMySql
            {
                Id = obj.Id,
                ContaGoogle = eContaGoogle,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataEdicao = DateTime.Now,
                Login = obj.Login,
                ResponsavelCriacao = obj.ResponsavelCriacao,
                ResponsavelEdicao = obj.ResponsavelEdicao,
                Senha = CriptoHashSha256.GetSha256Hash(obj.Senha)
            });
        }

        public async Task<List<PessoasAtivasMySqlViewModel>> ListarUsuariosAtivos(string idOrganizacao)
        {
            // pesquisar pessoas por organização
            IEnumerable<PessoaMySql> busca = _pessoaMySqlRepository.ListarTodas(idOrganizacao);

            // objeto view model para retorno
            List<PessoasAtivasMySqlViewModel> retorno = busca.Select(item => new PessoasAtivasMySqlViewModel
            {

                Id = item.Id,
                Nome = item.Nome,
                Email = item.Email,
                Status = item.Status
            }).ToList();

            return retorno;
        }
    }
}
