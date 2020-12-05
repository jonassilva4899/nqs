using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class ClientePerfilViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
