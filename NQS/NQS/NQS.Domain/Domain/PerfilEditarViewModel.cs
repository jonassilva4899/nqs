using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PerfilEditarViewModel
    {
        public Guid Id { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string FuncaoPrincipal { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string MiniBio { get; set; }
        public bool Status { get; set; }
        public bool eUsuario { get; set; }
        public bool eContaGoogle { get; set; }
        public OrganizacaoUsuarioRoleEnum? NivelPermissao { get; set; }
        public Guid IdResponsavelEdicao { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
    }
}
