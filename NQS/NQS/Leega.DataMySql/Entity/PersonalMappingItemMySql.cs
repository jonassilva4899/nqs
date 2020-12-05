using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class PersonalMappingItemMySql : BaseMySql
    {
        public string Item { get; set; }
        public string IdPersonalMappingTitulo { get; set; }
        public virtual PersonalMappingTituloMySql PersonalMappingTitulo { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public string IdOrganizacao { get; set; }
    }
}
