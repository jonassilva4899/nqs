using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class RecuperarSenhaMySql : BaseMySql
    {
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public bool Ativo { get; set; }
        public string Token { get; set; }
        public bool NotificacaoFoiEnviada { get; set; }
        public string MensagemResultadoNotificacao { get; set; }
        public string IdPessoa { get; set; }
        public virtual PessoaMySql Pessoa { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public string IdOrganizacao { get; set; }
    }
}
