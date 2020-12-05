using Leega.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Application.ViewModels
{
 public   class OrganizacaoUsuarioRoleMySqlViewModel: BaseMySqlViewModel
    {
        public OrganizacaoUsuarioRoleEnum Role { get; set; }
        public virtual ICollection<OrganizacaoUsuarioMySqlViewModel> OrganizacaoUsuarios { get; set; }
    }
}
