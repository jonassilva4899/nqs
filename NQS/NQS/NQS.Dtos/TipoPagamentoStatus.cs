using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Dtos
{
    public class TipoPagamentoStatus
    {
        public int id { get; set; }
        public int tipopagamentoid { get; set; }
        public string codigoadquirente { get; set; }
        public string descricao { get; set; }
        public bool finalizado { get; set; }
        public bool sucesso { get; set; }
    }
}
