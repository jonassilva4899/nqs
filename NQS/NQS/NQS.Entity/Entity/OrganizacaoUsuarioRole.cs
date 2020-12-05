using Leega.Entity.Entity;
using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Entity
{
    public class OrganizacaoUsuarioRole : BaseEntity
    {
        public OrganizacaoUsuarioRoleEnum Role { get; set; }
        public virtual ICollection<OrganizacaoUsuario> OrganizacaoUsuarios { get; set; }
    }
}
