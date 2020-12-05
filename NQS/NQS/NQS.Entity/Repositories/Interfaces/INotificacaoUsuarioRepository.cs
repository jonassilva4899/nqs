using Leega.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Entity.Repositories.Interfaces
{
    public interface INotificacaoUsuarioRepository : IRepository<NotificacaoUsuario>
    {
        //IEnumerable<NotificacaoUsuario> PegarTodasNotificacoes(Guid id, Guid idOrganizacao);
    }
}
