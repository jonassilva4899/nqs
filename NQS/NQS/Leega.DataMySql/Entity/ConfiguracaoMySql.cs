using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class ConfiguracaoMySql : BaseMySql
    {
        public string IdTime { get; set; }
        public bool Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public string IdOrganizacao { get; set; }
        public string Nome { get; set; }
        public string Chave { get; set; }
        public virtual TimeMySql Time { get; set; }
    }
}
