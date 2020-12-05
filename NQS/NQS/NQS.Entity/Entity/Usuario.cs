using Leega.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Leega.Entity.Entity;

namespace Leega.Entity
{
    public class Usuario : BaseEntity
    {     
        //public Guid IdOrganizacao { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public bool ContaGoogle { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }

        //public virtual ICollection<Seguidor> Seguidores { get; set; }
        public virtual ICollection<NotificacaoUsuario> NotificacaoUsuarios { get; set; }
        public virtual ICollection<OrganizacaoUsuario> Organizacoes { get; set; }
    }
}
