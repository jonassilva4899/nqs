using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Leega.Dtos
{
    public class Doacao
    {
        public Doacao()
        {
            campanhas = new List<DoacaoCampanha>();
        }

        public Guid id { get; set; }
        public int pessoaid { get; set; }
        public DateTime data { get; set; }
        public double valor { get; set; }
        public string identificador { get; set; }
        public bool anonimo { get; set; }
        public int recorrencia { get; set; }
        public double valortotal
        {
            get
            {
                try
                {
                    return recorrencia * campanhas.Select(x => x.valor).Sum();
                }
                catch
                {
                    return 0;
                }
            }
        }
        public List<DoacaoCampanha> campanhas { get; set; }
        public List<Dtos.DoacaoPagamento> pagamento { get; set; }
        public Dtos.Pessoa pessoa { get; set; }
    }
}
