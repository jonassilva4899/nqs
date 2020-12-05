using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class TimePessoaMySql
    {
        public string IdTime { get; set; }
        public string IdPessoa { get; set; }
        public string Papel { get; set; }
        public bool Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public string IdOrganizacao { get; set; }
        public virtual PessoaMySql Pessoa { get; set; }
        public virtual TimeMySql Time { get; set; }
    }
}
