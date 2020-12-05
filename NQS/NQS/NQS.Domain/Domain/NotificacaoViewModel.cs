using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class NotificacaoViewModel : BaseDomain
    {
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public string Tipo { get; set; }
        public bool ConfirmacaoLeitura { get; set; }
        public bool EnviadoPorEmail { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
        public virtual ICollection<NotificacaoUsuarioViewModel> NotificacaoUsuarios { get; set; }
    }
}
