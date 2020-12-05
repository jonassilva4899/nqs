using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leega.Entity
{
    public class ConviteHistorico : BaseEntity
    {
        public DateTime DataEnvio { get; set; }
        public DateTime DataExpiracao { get; set; }
        [Column(TypeName = "VARCHAR(1000)")]
        public string MensagemNotificacao { get; set; }
        public string Token { get; set; }
        public bool FoiEnviado { get; set; }
        [Column(TypeName = "VARCHAR(1000)")]
        public string MensagemResultadoNotificacao { get; set; }
        public Guid IdPessoaRequisita { get; set; }
        public virtual Pessoa PessoaRequisita { get; set; }
        public Guid IdConvite { get; set; }
        public virtual Convite Convite { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
    }
}
