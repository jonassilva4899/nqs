using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class GrupoViewModel : BaseDomain
    {
        public string Nome { get; set; }
        //public virtual ICollection<TimeGrupoViewModel> TimeGrupos { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public Guid IdOrganizacao { get; set; }
    }
}
