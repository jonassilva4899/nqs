using Leega.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Entity.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario PegarUsuarioLogin(Expression<Func<Usuario, bool>> predicate);
        Task<Usuario> PegarUsuario(Expression<Func<Usuario, bool>> predicate);
    }
}
