using Leega.Application.ViewModels;
using Leega.DataMySql.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Application.Interfaces
{
    public interface IPacienteMySqlService
    {
        void Adicionar(PacienteMySql obj);
        void Atualizar(PacienteMySql obj);
        Task<List<PacienteMySqlViewModel>> ListarTodos();
        Task<PacienteMySqlViewModel> Obter(Guid id);
    }
}
