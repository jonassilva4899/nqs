using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class InfoPlanningViewModel
    {
        public int QuantidadePlannings { get; set; }
        public DateTime? ProximaPlanning { get; set; }
        public DateTime? UltimaPlanning { get; set; }
        public bool PlanningConfigurada { get; set; }
    }
}
