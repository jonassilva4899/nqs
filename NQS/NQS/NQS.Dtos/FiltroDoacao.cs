using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Dtos
{
    public class FiltroDoacao
    {
        public FiltroDoacao()
        {
            campanhaid = new List<int>();
            ongid = new List<int>();
        }

        public List<int> campanhaid { get; set; }
        public List<int> ongid { get; set; }
    }
}
