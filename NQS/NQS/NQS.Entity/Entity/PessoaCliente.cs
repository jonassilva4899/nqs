using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Entity
{
    public class PessoaCliente
    {
        public Guid IdPessoa { get; set; }
        public Guid IdCliente { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Status { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual Cliente Cliente { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
    }
}
