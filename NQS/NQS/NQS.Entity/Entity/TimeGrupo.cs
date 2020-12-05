using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Entity
{
    public class TimeGrupo
    {
        public Guid IdTime { get; set; }
        public Guid IdGrupo { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public Guid IdOrganizacao { get; set; }
        public virtual Time Time { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
