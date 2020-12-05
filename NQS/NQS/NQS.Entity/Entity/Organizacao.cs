using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leega.Entity.Entity
{
    public class Organizacao : BaseEntity
    {
        [Column(TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }
        public string Foto { get; set; }
        [Column(TypeName = "VARCHAR(1000)")]
        public string Descricao { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string Localizacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime? DataEdicao { get; set; }
        public Guid? ResponsavelEdicao { get; set; }
        public virtual ICollection<OrganizacaoUsuario> Pessoas { get; set; }
        public virtual ICollection<Pessoa> UltimosAcessos { get; set; }
    }
}