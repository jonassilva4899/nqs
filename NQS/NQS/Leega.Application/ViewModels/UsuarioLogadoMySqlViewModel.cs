using Leega.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Application.ViewModels
{
    public class UsuarioLogadoMySqlViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public DateTime DataCriacao { get; set; }
        public string[] Permissoes { get; set; }
        public string Token { get; set; }
        public string Id { get; set; }
        public string IdPessoa { get; set; }
        public string IdOrganizacao { get; set; }
        public OrganizacaoUsuarioRoleEnum RoleEnum { get; set; }
        public List<string> IdsTimes { get; set; }
    }
}
