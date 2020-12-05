using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class EditarClientePerfilViewModel
    {
        public Guid IdPessoa { get; set; }
        public List<ClientePerfilViewModel> ClientesAntigos { get; set; }
        public List<ClientePerfilViewModel> ClientesNovos { get; set; }
    }
}
