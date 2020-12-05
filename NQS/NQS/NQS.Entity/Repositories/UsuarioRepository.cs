using Leega.Entity.Context;
using Leega.Entity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Entity.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(goobeeteamsContext context) : base(context)
        { }

        private goobeeteamsContext _appContext => (goobeeteamsContext)_context;

        public Usuario PegarUsuarioLogin(Expression<Func<Usuario, bool>> predicate)
        {
            return _appContext.Usuarios
                .Include(x => x.Organizacoes)
                    .ThenInclude(x => x.OrganizacaoUsuarioRole)
                .SingleOrDefault(predicate);
        }
        public async Task<Usuario> PegarUsuario(Expression<Func<Usuario, bool>> predicate)
        {
            return await _appContext.Usuarios
                .SingleOrDefaultAsync(predicate);
        }

    }
}
