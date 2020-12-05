using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class GrupoMySql : BaseMySql
    {
        public string Nome { get; set; }
        public virtual ICollection<TimeGrupoMySql> TimeGrupos { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public string IdOrganizacao { get; set; }
    }
}
