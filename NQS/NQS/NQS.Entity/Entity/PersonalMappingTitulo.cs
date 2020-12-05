using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Leega.Entity.Entity;

namespace Leega.Entity
{
    public class PersonalMappingTitulo : BaseEntity
    {
        [Column(TypeName = "VARCHAR(100)")]
        public string Titulo { get; set; }
        public Guid IdPessoa { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<PersonalMappingItem> PersonalMappingItens { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
    }
}
