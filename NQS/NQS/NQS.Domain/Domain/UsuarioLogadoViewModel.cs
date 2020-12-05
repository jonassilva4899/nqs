using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class UsuarioLogadoViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public DateTime DataCriacao { get; set; }
        public string[] Permissoes { get; set; }
        public string Token { get; set; }
        public Guid Id { get; set; }
        public Guid IdPessoa { get; set; }
        public Guid? IdOrganizacao { get; set; }
        public OrganizacaoUsuarioRoleEnum RoleEnum { get; set; }
        public List<Guid> IdsTimes { get; set; }
    }
}
