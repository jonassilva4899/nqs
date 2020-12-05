using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leega.Entity
{
    public class Cliente : BaseEntity
    {
        [Column(TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
        //public virtual ICollection<Projeto> Projetos { get; set; }
        public virtual ICollection<PessoaCliente> PessoaClientes { get; set; }
    }
}
