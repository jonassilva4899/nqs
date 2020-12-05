using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Dtos
{
    public class TipoPagamento
    {
        public int id { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
        public string codigoadquirente { get; set; }
        public List<TipoPagamentoStatus> tipopagamentostatus { get; set; }
    }
}
