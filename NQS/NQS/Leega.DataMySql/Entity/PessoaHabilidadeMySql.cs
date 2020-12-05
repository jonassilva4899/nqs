using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class PessoaHabilidadeMySql
    {
        public string IdPessoa { get; set; }
        public string IdHabilidade { get; set; }
        public virtual PessoaMySql Pessoa { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public string IdOrganizacao { get; set; }
    }
}
