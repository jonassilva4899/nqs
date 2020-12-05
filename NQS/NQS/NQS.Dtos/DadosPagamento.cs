using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Dtos
{
    public class DadosPagamento
    {
        public string validade { get; set; }

        public string nome { get; set; }

        public string numero { get; set; }

        public string codigo { get; set; }
        public int vencimento { get; set; }
    }
}
