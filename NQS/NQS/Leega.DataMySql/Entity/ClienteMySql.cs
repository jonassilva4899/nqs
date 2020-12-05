using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class ClienteMySql : BaseMySql
    {
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public string IdOrganizacao { get; set; }
        public virtual ICollection<PessoaClienteMySql> PessoaClientes { get; set; }
    }
}
