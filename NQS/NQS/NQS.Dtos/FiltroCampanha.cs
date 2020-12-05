using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Dtos
{
    public class FiltroCampanha
    {
        public string nome { get; set; }
        public List<string> uf { get; set; }
        public List<int> tipo { get; set; }
    }
}
