using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PerguntaEnpsEmailViewModel
    {
        public Guid IdPesquisaPergunta { get; set; }
        public string Texto { get; set; }
        public Guid IdOrganizacao { get; set; }
    }
}
