using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leega.Entity
{
    public class PersonalMappingItem : BaseEntity
    {
        [Column(TypeName = "VARCHAR(1000)")]
        public string Item { get; set; }
        public Guid IdPersonalMappingTitulo { get; set; }
        public virtual PersonalMappingTitulo PersonalMappingTitulo { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
    }
}
