using Leega.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class OrganizacaoUsuarioRoleMySql : BaseMySql
    {
        public OrganizacaoUsuarioRoleEnum Role { get; set; }
        public virtual ICollection<OrganizacaoUsuarioMySql> OrganizacaoUsuarios { get; set; }
    }
}
