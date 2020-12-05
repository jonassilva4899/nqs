using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leega.Entity
{
    public class Convite : BaseEntity
    {
        [Column(TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string Email { get; set; }
        public ConviteStatusEnum Status { get; set; }
        public Guid IdPessoaCriada { get; set; }
        public virtual Pessoa PessoaCriada { get; set; }
        public virtual ICollection<ConviteHistorico> ConvitesHistorico { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
    }
}
