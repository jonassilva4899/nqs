using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leega.Entity.Entity;
using Leega.Entity.Repository;

namespace Leega.Entity.Repositories.Interfaces
{
    public interface IOrganizacaoRepository : IRepository<Organizacao>
    {
        Task<List<Organizacao>> Listar(Guid idUsuario);
        Task<List<Organizacao>> ListarGoobeeAdmin();
        Task<List<Organizacao>> ListarApiPublica();
        Task<OrganizacaoUsuario> BuscaOrganizacaoPorPessoa(Guid idOrganizacao, Guid idPessoa);
        Task<Organizacao> Selecionar(Guid idOrganizacao);
    }
}