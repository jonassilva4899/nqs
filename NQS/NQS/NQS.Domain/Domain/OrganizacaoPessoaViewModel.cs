using Leega.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class OrganizacaoPessoaViewModel : BaseDomain
    {
        public Guid IdPessoa { get; set; }
        public Guid IdOrganizacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        public virtual OrganizacaoEntityViewModel Organizacao { get; set; }
    }
}
