using System;
using System.Collections.Generic;
using System.Text;
using Leega.Entity.Enums;

namespace Leega.Domain
{
    public class PerfilViewModel
    {
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string FuncaoPrincipal { get; set; }
        public string UltimoCliente { get; set; }
        public string MiniBio { get; set; }
        public int QuantidadeVisitas { get; set; }
        public DateTime? UltimoCheckpoint { get; set; }
        public DateTime? ProximoCheckpoint { get; set; }
        public bool SenhaCriada { get; set; }
        public SentimentoColaboradorEnum MediaSentimentoColaborador { get; set; }
    }
}
