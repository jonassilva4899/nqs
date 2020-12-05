using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain.Domain
{
    public class AssociaContaGoogleViewModel
    {
        public Guid IdRecuperarSenha { get; set; }
        [Required]
        public Guid IdConviteHistorico { get; set; }
        public UsuarioSocialViewModel UsuarioSocial { get; set; }
    }
}
