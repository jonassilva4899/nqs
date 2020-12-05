using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class MotivadorViewModel : BaseDomain
    {
        public string Nome { get; set; }
        public string Foto { get; set; }
        public virtual ICollection<PessoaMotivadorViewModel> PessoaMotivadores { get; set; }
    }
}
