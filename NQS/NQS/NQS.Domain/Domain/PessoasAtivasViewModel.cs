using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PessoasAtivasViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
