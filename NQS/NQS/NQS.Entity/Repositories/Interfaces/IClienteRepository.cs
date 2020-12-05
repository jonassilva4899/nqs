using Leega.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Entity.Repositories.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IEnumerable<Cliente> PegarTodosClientes(Guid idOrganizacao);
    }
}
