﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class RecuperarSenhaViewModel : BaseDomain
    {
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public bool Ativo { get; set; }
        public string Token { get; set; }
        public bool NotificacaoFoiEnviada { get; set; }
        public string MensagemResultadoNotificacao { get; set; }
        public Guid IdPessoa { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
    }
}
