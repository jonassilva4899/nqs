using Leega.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Entity.Repositories.Interfaces
{
    public interface ITimeRepository : IRepository<Time>
    {
        IEnumerable<Time> PegarTodosTimesComMembros();
        IEnumerable<Time> PegarTimesComMembros(Expression<Func<Time, bool>> predicate);
        Time PegarUmTimeComMembros(Expression<Func<Time, bool>> predicate);
        Time PegarUmTimeApenasComMembros(Expression<Func<Time, bool>> predicate);
        Time PegarUmTimeComTimePessoas(Expression<Func<Time, bool>> predicate);
        List<Time> PegarTimesPessoaComFotoComboBox(Expression<Func<Time, bool>> predicate);
        IEnumerable<Time> PegarTodosTimesComTimePessoas();
        IEnumerable<Time> PegarTodosTimes(Guid idOrganizacao);
        Task<IEnumerable<Time>> PegarTodosTimesPB(Expression<Func<Time, bool>> predicate);
        IEnumerable<Time> PegarTodosTimes(Expression<Func<Time, bool>> predicate);
        IEnumerable<Time> GetTimeAtributos(Expression<Func<Time, bool>> predicate);
        Task<Time> PegarPorId(Guid id, Guid idOrganizacao);
        Task<Time> PegarUmTimeComDaily(Guid idTime, Guid idOrganizacao);
        Task<Time> PegarUmTimeComPlanning(Guid idTime, Guid idOrganizacao);
        Task<Time> PegarUmTimeComRetrospectiva(Guid idTime, Guid idOrganizacao);
        IEnumerable<Time> PegarTimesComProjetos(Expression<Func<Time, bool>> predicate);
        IEnumerable<Time> PegarTimesComPraticasPessoas(Expression<Func<Time, bool>> predicate);
        IEnumerable<Time> PegarTimesComMelhoriaContinua(Expression<Func<Time, bool>> predicate);
    }

}
