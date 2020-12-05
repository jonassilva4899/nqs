using Leega.Entity.Entity;
using Leega.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Entity.Repositories.Interfaces
{
    public interface IOrganizacaoPessoaRepository : IRepository<OrganizacaoUsuario>
    {
        //Task<List<Pessoa>> BuscarPessoasPorOrganizacao(Guid idOrganizacao);
        Task<OrganizacaoUsuario> BuscarPorEmailUsuario(string email, Guid idOrganizacao);
        Task<OrganizacaoUsuario> BuscarPorEmailPessoa(string email, Guid idOrganizacao);
        Task<OrganizacaoUsuario> BuscarPorOrganizacao(Guid idOrganizacao, string email);
    }
}
