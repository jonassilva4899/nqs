//using Leega.Entity.Context;
//using Leega.Entity.Repositories.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Leega.Entity.Repositories
//{
//    public class NotificacaoUsuarioRepository : Repository<NotificacaoUsuario>, INotificacaoUsuarioRepository
//    {
//        private goobeeteamsContext _appContext => (goobeeteamsContext)_context;

//        public NotificacaoUsuarioRepository(goobeeteamsContext context) : base(context)
//        { }

//        //public IEnumerable<NotificacaoUsuario> PegarTodasNotificacoes(Guid id, Guid idOrganizacao)
//        //{            
//        //        return _appContext.NotificacaoUsuarios
//        //            .Include(x => x.Notificacao)                       
//        //            .Where(x => x.IdUsuario == id && x.IdOrganizacao == idOrganizacao);      
//        //}
//    }
//}
