using Leega.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leega.Entity
{
    public class Notificacao : BaseEntity
    {
        [Column(TypeName = "VARCHAR(50)")]
        public string Titulo { get; set; }
        [Column(TypeName = "VARCHAR(1000)")]
        public string Mensagem { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public string Tipo { get; set; }
        public bool ConfirmacaoLeitura { get; set; }
        public bool EnviadoPorEmail { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
        public virtual List<NotificacaoUsuario> NotificacaoUsuarios { get; set; }
    }
}
