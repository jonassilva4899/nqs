using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain
{
    public class ClienteAdicionarViewModel
    {
        public Guid IdCliente { get; set; }
        [Required]
        public Guid IdPessoa { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
