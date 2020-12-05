using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain
{
    public class ClienteViewModel : BaseDomain
    {
        [Required]
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
        //public virtual ICollection<ProjetoViewModel> Projetos { get; set; }
        public virtual ICollection<PessoaClienteViewModel> PessoaClientes { get; set; }
    }
}
