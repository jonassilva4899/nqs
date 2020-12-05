using Leega.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Entity.Repositories.Interfaces
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        IEnumerable<Pessoa> GetTopPessoas(Expression<Func<Pessoa, bool>> predicate, int count);
        IEnumerable<Pessoa> PegarTodasPessoas(Guid idOrganizacao);
        IEnumerable<Pessoa> PegarTodasPessoasNaoInclusivoSemUsuario(Guid? idPessoa, Guid idOrganizacao);
        IEnumerable<Pessoa> PegarTodasPessoasNaoInclusivo(Guid idPessoa, Guid idOrganizacao);
        Pessoa PegarPessoaComTimePessoasTime(Expression<Func<Pessoa, bool>> predicate);
        Pessoa PegarPessoaComTimePessoas(Expression<Func<Pessoa, bool>> predicate);
        //Pessoa PegarPerfilPessoa(Expression<Func<Pessoa, bool>> predicate);
        Task<Pessoa> BuscarPessoaPorId(Guid idPessoa);
        Task<Pessoa> GetPorId(Guid id, Guid idOrganizacao);
        Task<Pessoa> GetPorIdComUsuario(Guid idPessoa, Guid idOrganizacao);
        Task<List<OrganizacaoUsuario>> BuscarOrganizacoes(string pessoaEmail);
        Task<Pessoa> BuscarPorEmail(string email);
    }
}
