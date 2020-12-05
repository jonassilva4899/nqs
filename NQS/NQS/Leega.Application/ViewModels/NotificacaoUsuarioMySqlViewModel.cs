using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Application.ViewModels
{
    public class NotificacaoUsuarioMySqlViewModel
    {
        public string IdNotificacao { get; set; }
        public string IdUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public string IdOrganizacao { get; set; }
        public virtual UsuarioMySqlViewModel Usuario { get; set; }
        public virtual NotificacaoMySqlViewModel Notificacao { get; set; }
    }
}
