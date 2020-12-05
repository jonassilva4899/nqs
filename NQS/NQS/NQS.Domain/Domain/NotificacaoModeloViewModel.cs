using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class NotificacaoModeloViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public string Tipo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
