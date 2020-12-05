using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class EditarTimePerfilViewModel
    {
        public Guid IdPessoa { get; set; }
        public List<TimePerfilViewModel> TimesAntigos { get; set; }
        public List<TimePerfilViewModel> TimesNovos { get; set; }
    }
}
