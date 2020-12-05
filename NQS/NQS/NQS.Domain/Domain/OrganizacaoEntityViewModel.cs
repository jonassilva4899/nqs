using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class OrganizacaoEntityViewModel : BaseDomain
    {
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime? DataEdicao { get; set; }
        public Guid? ResponsavelEdicao { get; set; }
        public virtual ICollection<OrganizacaoPessoaViewModel> Pessoas { get; set; }
    }
}
