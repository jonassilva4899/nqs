using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain
{
    public class InserirSenhaViewModel
    {
        public Guid IdRecuperarSenha { get; set; }
        [Required]
        public Guid IdConviteHistorico { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool ContaGoogle { get; set; }
        public bool ExisteErroLogin { get; set; }
        public string MensagemErro { get; set; }
        public string MensagemSucesso { get; set; }
        [Required]
        public string NovaSenha { get; set; }
        [Required]
        public string ConfirmacaoNovaSenha { get; set; }
    }
}
