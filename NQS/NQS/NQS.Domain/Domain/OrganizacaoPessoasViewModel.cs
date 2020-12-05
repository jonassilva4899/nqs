using System;

namespace Leega.Domain.Domain
{
    public class UsuarioOrganizacaoViewModel
    {
        public Guid IdOrganizacao { get; set; }
        public Guid IdPessoa { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public PessoaViewModel Pessoa { get; set; }
        public OrganizacaoViewModel Organizacao { get; set; }
    }
}