using Leega.DataMySql.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Repositories.Interfaces
{
    public interface IClienteMySqlRepository
    {
        IEnumerable<ClienteMySql> ListarTodos(string idOrganizacao);
        IEnumerable<ClienteMySql> ListarTodos();
        ClienteMySql Obter(ClienteMySql obj);
        void Adicionar(ClienteMySql obj);
        void Atualizar(ClienteMySql obj);
        void Remover(ClienteMySql obj);
    }
}
