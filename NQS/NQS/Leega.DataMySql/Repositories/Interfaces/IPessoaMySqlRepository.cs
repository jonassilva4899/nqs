using Leega.DataMySql.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leega.DataMySql.Repositories.Interfaces
{
    public interface IPessoaMySqlRepository
    {
        void Adicionar(PessoaMySql obj);
        Task<PessoaMySql> BuscarPorEmail(string email);
        IEnumerable<PessoaMySql> ListarTodas(string idOrganizacao);
    }
}
