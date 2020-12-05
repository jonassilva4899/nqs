using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class NotificacaoMySql : BaseMySql
    {
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public string Tipo { get; set; }
        public bool ConfirmacaoLeitura { get; set; }
        public bool EnviadoPorEmail { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public string IdOrganizacao { get; set; }
        public virtual List<NotificacaoUsuarioMySql> NotificacaoUsuarios { get; set; }
    }
}
