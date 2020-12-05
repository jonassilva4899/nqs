using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain
{
    public class SenhasHashsViewModel
    {
        [Required]
        public string Senha { get; set; }
        [Required]
        public string ConfirmarSenha { get; set; }
        [Required]
        public string IdRecuperarSenhaHash { get; set; }
        [Required]
        public string TokenHash { get; set; }
    }
}
