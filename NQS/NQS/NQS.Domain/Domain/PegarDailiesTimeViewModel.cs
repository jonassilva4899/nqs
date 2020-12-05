using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PegarDailiesTimeViewModel
    {
        public Guid IdDaily { get; set; }
        public string NomeResponsavelRegistro { get; set; }
        public DateTime? DataHoraRegistro { get; set; }
        public string Observacao { get; set; }
    }
}
