using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class EmailNotificacaoViewModel
    {
        public string EmailDestinatario { get; set; }
        public string EmailRemetente { get; set; }
        public string Mensagem { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public DateTime Data { get; set; }
        public string Organizacao { get; set; }
    }
}
