using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class OrganizacaoMySql : BaseMySql
    {
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime? DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public virtual ICollection<OrganizacaoUsuarioMySql> Pessoas { get; set; }
        public virtual ICollection<PessoaMySql> UltimosAcessos { get; set; }
    }
}
