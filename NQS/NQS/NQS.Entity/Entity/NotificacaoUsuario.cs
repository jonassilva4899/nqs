using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Entity
{
    public class NotificacaoUsuario
    {
        public Guid IdNotificacao { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Notificacao Notificacao { get; set; }
    }
}
