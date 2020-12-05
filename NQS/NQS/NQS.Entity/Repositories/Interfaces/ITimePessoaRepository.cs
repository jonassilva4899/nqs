using Leega.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Leega.Entity.Repositories.Interfaces
{
    public interface ITimePessoaRepository : IRepository<TimePessoa>
    {
        IEnumerable<TimePessoa> PegarTimePessoasSentimentos(Expression<Func<TimePessoa, bool>> predicate);
        public IEnumerable<TimePessoa> PegarPessoasEnvioEmail(Guid idTime, Guid idOrganizacao);
    }
}
