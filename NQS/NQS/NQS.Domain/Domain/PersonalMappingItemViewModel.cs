using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PersonalMappingItemViewModel : BaseDomain
    {
        public string Item { get; set; }
        public Guid IdPersonalMappingTitulo { get; set; }
        public virtual PersonalMappingTituloViewModel PersonalMappingTitulo { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
    }
}
