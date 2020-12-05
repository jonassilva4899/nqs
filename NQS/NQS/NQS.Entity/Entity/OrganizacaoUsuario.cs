using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leega.Entity.Entity
{
    public class OrganizacaoUsuario
    {
        public Guid IdPessoa { get; set; }
        public Guid IdOrganizacao { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdOrganizacaoUsuarioRole { get; set; }
        public bool UsuarioPlataforma { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string FuncaoPrincipal { get; set; }
        public bool UltimaAcessada { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual Organizacao Organizacao { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual OrganizacaoUsuarioRole OrganizacaoUsuarioRole { get; set; }
    }
}