using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain
{
    public class PessoaAdicionarViewModel
    {
        [Required]
        public AdicionarPessoaViewModel Pessoa { get; set; }
        [Required]
        public Guid PessoaRequisitando { get; set; }
        public bool eUsuario { get; set; }
        public bool eContaGoogle { get; set; }
    }
}
