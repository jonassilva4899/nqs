using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Leega.Entity.Entity;

namespace Leega.Entity
{
    public class Pessoa : BaseEntity
    {
        [Column(TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }
        public string Foto { get; set; }
        [Column(TypeName = "VARCHAR(20)")]
        public string Telefone { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR(1000)")]
        public string MiniBio { get; set; }
        public bool Status { get; set; }
        public bool GoobeeAdmin { get; set; }
        public Guid? IdUltimaOrgAcessada { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public virtual Organizacao UltimaOrgAcessada { get; set; }
        public virtual ICollection<RecuperarSenha> RecuperarSenhas { get; set; }
        public virtual ICollection<TimePessoa> TimePessoas { get; set; }
        public virtual ICollection<PessoaCliente> PessoaClientes { get; set; }
        public virtual ICollection<OrganizacaoUsuario> Organizacoes { get; set; }
        public virtual ICollection<PersonalMappingTitulo> PersonalMappingTitulos { get; set; }
        public virtual ICollection<PessoaHabilidade> PessoaHabilidades { get; set; }
    }
}