using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class NotificacaoUsuarioMySql
    {
        public string IdNotificacao { get; set; }
        public string IdUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public string IdOrganizacao { get; set; }
        public virtual UsuarioMySql Usuario { get; set; }
        public virtual NotificacaoMySql Notificacao { get; set; }
    }
}
