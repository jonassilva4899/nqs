using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PegarMotivadoresViewModel
    {
        public Guid IdPessoa { get; set; }
        public List<PegarMotivadorViewModel> Motivadores { get; set; } = new List<PegarMotivadorViewModel>();
    }

    public class PegarMotivadorViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Indice { get; set; }
    }
}
