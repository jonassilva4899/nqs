using Leega.Entity.Context;
using Leega.Entity.Entity;
using Leega.Entity.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Leega.Entity.Repositories
{
    public class OrganizacaoUsuarioRepository : Repository<OrganizacaoUsuario>, IOrganizacaoUsuarioRepository
    {
        public OrganizacaoUsuarioRepository(goobeeteamsContext context) : base(context)
        { }

        private goobeeteamsContext _appContext => (goobeeteamsContext)_context;

      
    }
}
