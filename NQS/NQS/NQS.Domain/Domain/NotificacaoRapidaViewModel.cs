using Leega.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class NotificacaoRapidaViewModel
    {
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public Guid IdResponsavel { get; set; }
        public Guid IdOrganizacao { get; set; }
        public bool EnviadoPorEmail { get; set; }
        public Usuario UsuarioDestino { get; set; }
    }
}
