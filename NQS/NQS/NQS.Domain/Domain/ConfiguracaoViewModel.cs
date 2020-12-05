using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class ConfiguracaoViewModel : BaseDomain
    {
        public Guid IdTime { get; set; }
        public bool Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
        public string Nome { get; set; }
        public string Chave { get; set; }
        //public virtual TimeViewModel Time { get; set; }
    }
}
