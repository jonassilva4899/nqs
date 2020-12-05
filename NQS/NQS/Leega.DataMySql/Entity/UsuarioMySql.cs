using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class UsuarioMySql : BaseMySql
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public bool ContaGoogle { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }

        public virtual ICollection<NotificacaoUsuarioMySql> NotificacaoUsuarios { get; set; }
        public virtual ICollection<OrganizacaoUsuarioMySql> Organizacoes { get; set; }
    }
}
