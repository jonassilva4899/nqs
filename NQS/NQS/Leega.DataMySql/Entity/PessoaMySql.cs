using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class PessoaMySql : BaseMySql
    {
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string MiniBio { get; set; }
        public bool Status { get; set; }
        public bool GoobeeAdmin { get; set; }
        public string IdUltimaOrgAcessada { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }

        public virtual OrganizacaoMySql UltimaOrgAcessada { get; set; }
        public virtual ICollection<RecuperarSenhaMySql> RecuperarSenhas { get; set; }
        public virtual ICollection<TimePessoaMySql> TimePessoas { get; set; }
        public virtual ICollection<PessoaClienteMySql> PessoaClientes { get; set; }
        public virtual ICollection<OrganizacaoUsuarioMySql> Organizacoes { get; set; }
        public virtual ICollection<PersonalMappingTituloMySql> PersonalMappingTitulos { get; set; }
        public virtual ICollection<PessoaHabilidadeMySql> PessoaHabilidades { get; set; }
    }
}
