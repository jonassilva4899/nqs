using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leega.HotSite.Models
{
    public class Tranparencia
    {
        public List<Models.Campanha> campanhas { get; set; }
        public List<Models.Ong> ongs { get; set; }
        public dynamic totais { get; set; }
    }
}
