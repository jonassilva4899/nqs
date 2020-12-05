using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leega.Entity
{
    public class RecuperarSenha : BaseEntity
    {
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public bool Ativo { get; set; }
        public string Token { get; set; }
        public bool NotificacaoFoiEnviada { get; set; }
        [Column(TypeName = "VARCHAR(1000)")]
        public string MensagemResultadoNotificacao { get; set; }
        public Guid IdPessoa { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
    }
}
