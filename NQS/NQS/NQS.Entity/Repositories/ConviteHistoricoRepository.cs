using Leega.Entity.Context;
using Leega.Entity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Entity.Repositories
{
    public class ConviteHistoricoRepository : Repository<ConviteHistorico>, IConviteHistoricoRepository
    {
        private goobeeteamsContext _appContext => (goobeeteamsContext)_context;
        public ConviteHistoricoRepository(goobeeteamsContext context) : base(context)
        { }

        public async Task<ConviteHistorico> PegarConvitesHistoricoComConvite(Expression<Func<ConviteHistorico, bool>> predicate)
        {
            return await _appContext.ConvitesHistorico
                         .Include(x => x.Convite)
                         .ThenInclude(x => x.PessoaCriada)
                         .FirstOrDefaultAsync(predicate);
        }
    }
}
