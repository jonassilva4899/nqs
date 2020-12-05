using Leega.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Application.Interfaces
{
    public interface IUsuarioMySqlService
    {
        void Adicionar(UsuarioMySqlViewModel obj, bool eContaGoogle);
        Task<List<PessoasAtivasMySqlViewModel>> ListarUsuariosAtivos(string idOrganizacao);
    }
}
