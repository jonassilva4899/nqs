using Leega.Entity.Context;
using Leega.Entity.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Entity.Repositories
{
    public class GrupoRepository : Repository<Grupo>, IGrupoRepository
    {
        public GrupoRepository(goobeeteamsContext context) : base(context)
        { }

        private goobeeteamsContext _appContext => (goobeeteamsContext)_context;
    }
}
