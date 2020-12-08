using Leega.DataMySql.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leega.DataMySql.Repositories.Interfaces
{
    public interface IPacienteMySqlRepository
    {
        void Adicionar(PacienteMySql obj);
        void Atualizar(PacienteMySql obj);

        IEnumerable<PacienteMySql> ListarTodos();

        PacienteMySql Obter(PacienteMySql obj);
    }
}
