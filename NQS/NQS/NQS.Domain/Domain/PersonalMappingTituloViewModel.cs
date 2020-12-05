using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PersonalMappingTituloViewModel : BaseDomain
    {
        public string Titulo { get; set; }
        public Guid IdPessoa { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        public virtual ICollection<PersonalMappingItemViewModel> PersonalMappingItens { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
    }
}
