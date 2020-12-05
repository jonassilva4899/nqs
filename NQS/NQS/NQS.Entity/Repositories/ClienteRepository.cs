using Leega.Entity.Context;
using Leega.Entity.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leega.Entity.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(goobeeteamsContext context) : base(context)
        { }

        private goobeeteamsContext _appContext => (goobeeteamsContext)_context;

        public IEnumerable<Cliente> PegarTodosClientes(Guid idOrganizacao)
        {
            return _appContext.Clientes.Where(x => x.IdOrganizacao == idOrganizacao).ToList();
        }
    }
}
