using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class TimeGrupoMySql
    {
        public string IdTime { get; set; }
        public string IdGrupo { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public string IdOrganizacao { get; set; }
        public virtual TimeMySql Time { get; set; }
        public virtual GrupoMySql Grupo { get; set; }
    }
}
