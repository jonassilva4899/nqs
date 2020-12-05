using System;
using System.Collections.Generic;
using System.Text;
using Leega.Entity.Entity;

namespace Leega.Entity
{
    public class PessoaHabilidade
    {
        public Guid IdPessoa { get; set; }
        public Guid IdHabilidade { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        //public virtual Habilidade Habilidade { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public Guid IdOrganizacao { get; set; }
    }
}
