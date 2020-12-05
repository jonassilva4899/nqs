using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Dtos
{
    public class Campanha
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public string uf { get; set; }
        public string cidade { get; set; }
        public string nome { get; set; }
        public string url { get; set; }
        public string descricao { get; set; }
        public string imagem { get; set; }
        public string covid { get; set; }
        public string linkvideo { get; set; }
        public string beneficiario { get; set; }
        public string conta { get; set; }
        public string plano { get; set; }
        public string centrocusto { get; set; }
        public double valorminimo { get; set; }
        public string privacidade { get; set; }
        public bool status { get; set; }
        public bool unica { get; set; }
        public bool recorrente { get; set; }
        public bool parcelado { get; set; }
        public bool cc { get; set; }
        public bool boleto { get; set; }
        public Ong ong { get; set; }
    }
}
