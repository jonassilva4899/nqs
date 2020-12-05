using Leega.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leega.HotSite.Models
{
    public class Causa
    {
        public List<Models.TipoCausa> tiposcausa { get; set; }
        public List<Dtos.Campanha> campanhas { get; set; }
        public List<Models.Estados> estado { get; set; }
        public string campanha { get; set; }
    }
}
