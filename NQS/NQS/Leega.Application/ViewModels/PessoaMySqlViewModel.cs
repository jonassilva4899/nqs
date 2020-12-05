using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Application.ViewModels
{
    public class PessoaMySqlViewModel : BaseMySqlViewModel
    {
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string FuncaoPrincipal { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string MiniBio { get; set; }
        public bool Status { get; set; }
        public bool GoobeeAdmin { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
        //public virtual ICollection<RecuperarSenhaMySqlViewModel> RecuperarSenhas { get; set; }
        //public virtual ICollection<PessoaClienteMySqlViewModel> PessoaClientes { get; set; }
        //public virtual ICollection<PersonalMappingTituloMySqlViewModel> PersonalMappingTitulos { get; set; }
        //public virtual ICollection<PessoaHabilidadeMySqlViewModel> PessoaHabilidades { get; set; }
        //public virtual ICollection<PessoaMotivadorMySqlViewModel> PessoaMotivadores { get; set; }
        //public virtual ICollection<OrganizacaoPessoaMySqlViewModel> Organizacoes { get; set; }
    }
}
