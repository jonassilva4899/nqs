using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PessoaMotivadorViewModel
    {
        public Guid IdPessoa { get; set; }
        public Guid IdMotivador { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        public virtual MotivadorViewModel Motivador { get; set; }
        public int Indice { get; set; }
    }
}
