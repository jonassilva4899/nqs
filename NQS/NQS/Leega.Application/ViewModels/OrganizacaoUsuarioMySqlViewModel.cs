using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Application.ViewModels
{
    public class OrganizacaoUsuarioMySqlViewModel
    {
        public string IdPessoa { get; set; }
        public string IdOrganizacao { get; set; }
        public string IdUsuario { get; set; }
        public string IdOrganizacaoUsuarioRole { get; set; }
        public bool UsuarioPlataforma { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public string FuncaoPrincipal { get; set; }
        public bool UltimaAcessada { get; set; }
        public virtual PessoaMySqlViewModel Pessoa { get; set; }
        public virtual OrganizacaoMySqlViewModel Organizacao { get; set; }
        public virtual UsuarioMySqlViewModel Usuario { get; set; }
        public virtual OrganizacaoUsuarioRoleMySqlViewModel OrganizacaoUsuarioRole { get; set; }
    }
}
