using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PessoaHabilidadeViewModel
    {
        public Guid IdPessoa { get; set; }
        public Guid IdHabilidade { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        //public virtual HabilidadeViewModel Habilidade { get; set; }
    }
}
