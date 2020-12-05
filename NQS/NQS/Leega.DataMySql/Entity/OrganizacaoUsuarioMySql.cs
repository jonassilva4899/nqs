using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class OrganizacaoUsuarioMySql
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
        public virtual PessoaMySql Pessoa { get; set; }
        public virtual OrganizacaoMySql Organizacao { get; set; }
        public virtual UsuarioMySql  Usuario { get; set; }
        public virtual OrganizacaoUsuarioRoleMySql OrganizacaoUsuarioRole { get; set; }
    }
}
