using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PegarClientePessoaViewModel
    {
        public Guid IdPessoa { get; set; }
        public List<ClientePerfilViewModel> ClientesPessoa { get; set; }
        public List<ClientePerfilViewModel> TodosClientes { get; set; }
    }
}
