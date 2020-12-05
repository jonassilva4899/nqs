using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Entity.Repositories.Interfaces
{
    public interface IConviteHistoricoRepository : IRepository<ConviteHistorico>
    {
        Task<ConviteHistorico> PegarConvitesHistoricoComConvite(Expression<Func<ConviteHistorico, bool>> predicate);
    }
}
