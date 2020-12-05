using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain
{
    public class AdicionarPessoaViewModel
    {
        [Required]
        public string Nome { get; set; }
        public string Foto { get; set; }
        [Required]
        public string FuncaoPrincipal { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string MiniBio { get; set; }
        public bool Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        [Required]
        public Guid IdTime { get; set; }
        public Guid IdOrganizacao { get; set; }
        public OrganizacaoUsuarioRoleEnum? NivelPermissao { get; set; }
    }


    public class AdicionarClienteFakeViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
