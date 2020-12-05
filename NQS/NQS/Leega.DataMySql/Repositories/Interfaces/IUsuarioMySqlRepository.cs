using Leega.DataMySql.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leega.DataMySql.Repositories.Interfaces
{
    public interface IUsuarioMySqlRepository
    {
        void Adicionar(UsuarioMySql obj);
        Task<UsuarioMySql> ObterUsuarioAsync(UsuarioMySql objeto);
        UsuarioMySql ObterUsuarioLogin(UsuarioMySql objeto);
    }
}
