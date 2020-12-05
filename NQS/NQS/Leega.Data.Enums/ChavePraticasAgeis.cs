using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Data.Enums
{
    public class ChavePraticasAgeis
    {
        private ChavePraticasAgeis(string value) { Value = value; }

        public string Value { get; set; }

        public static ChavePraticasAgeis Planning { get { return new ChavePraticasAgeis("PLNNNG"); } }
        public static ChavePraticasAgeis Review { get { return new ChavePraticasAgeis("REVIEW"); } }
        public static ChavePraticasAgeis MelhoriaContinua { get { return new ChavePraticasAgeis("MLR_CTN"); } }
        public static ChavePraticasAgeis Retrospectiva { get { return new ChavePraticasAgeis("RTSPCTV"); } }
        public static ChavePraticasAgeis DelegationBoard { get { return new ChavePraticasAgeis("DLGTN_BRD"); } }
        public static ChavePraticasAgeis TeamMood { get { return new ChavePraticasAgeis("TM_NC"); } }
        public static ChavePraticasAgeis DicasAgileCoach { get { return new ChavePraticasAgeis("DICA_AC"); } }
        public static ChavePraticasAgeis Daily { get { return new ChavePraticasAgeis("DAILY"); } }
        public static ChavePraticasAgeis Indicador { get { return new ChavePraticasAgeis("INDCDR"); } }
    }
}
