using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Dtos
{
    public class Estados
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
        public int? ibge { get; set; }
        public int? sl { get; set; }
        public string ddd { get; set; }
    }
}
