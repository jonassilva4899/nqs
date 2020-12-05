using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class PessoaClienteMySql
    {
        public string IdPessoa { get; set; }
        public string IdCliente { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Status { get; set; }
        public virtual PessoaMySql Pessoa { get; set; }
        public virtual ClienteMySql Cliente { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public string IdOrganizacao { get; set; }
    }
}
