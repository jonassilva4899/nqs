using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class ListarPessoasViewModel : BaseDomain
    {
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string FuncaoPrincipal { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string UltimoCliente { get; set; }
        public DateTime? UltimoCheckpoint { get; set; }
        public DateTime? ProximoCheckpoint { get; set; }
        public Guid IdOrganizacao { get; set; }
        public List<Guid> IdsTimes { get; set; }
    }
}
