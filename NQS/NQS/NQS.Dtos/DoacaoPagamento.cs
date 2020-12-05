using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Dtos
{
    public class DoacaoPagamento
    {
        public DoacaoPagamento()
        {
            result = new Result();
        }

        public int id { get; set; }
        public DateTime data { get; set; }
        public Guid doacaoid { get; set; }
        public string identificacao { get; set; }
        public string status { get; set; }
        public string statusid { get; set; }
        public Nullable<DateTime> datastatus { get; set; }
        public DadosPagamento dadospagamento { get; set; }
        public Doacao doacao { get; set; }
        public int tipopagamentoid { get; set; }
        public TipoPagamento tipopagamento { get; set; }
        public TipoPagamentoStatus tipopagamentostatus { get; set; }
        public Result result { get; set; }
    }
}
