using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class InfoRetrospectivaViewModel
    {
        public int QuantidadeRetrospectivas { get; set; }
        public DateTime? ProximaRetrospectiva { get; set; }
        public DateTime? UltimaRetrospectiva { get; set; }
        public bool RetrospectivaConfigurada { get; set; }
    }
}
