using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class PersonalMappingTituloMySql : BaseMySql
    {
        public string Titulo { get; set; }
        public string IdPessoa { get; set; }
        public virtual PessoaMySql Pessoa { get; set; }
        public virtual ICollection<PersonalMappingItemMySql> PersonalMappingItens { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public string IdOrganizacao { get; set; }
    }
}
