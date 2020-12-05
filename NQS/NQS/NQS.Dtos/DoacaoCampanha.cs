using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Dtos
{
    public class DoacaoCampanha
    {
        public int id { get; set; }
        public int campanhaid { get; set; }
        public string beneficiario { get; set; }
        public string nome { get; set; }
        public Guid doacaoid { get; set; }
        public double valor { get; set; }
        public Campanha campanha { get; set; }
    }
}
