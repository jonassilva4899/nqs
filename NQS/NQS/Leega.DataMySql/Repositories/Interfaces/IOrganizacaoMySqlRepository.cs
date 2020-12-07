﻿using Leega.DataMySql.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leega.DataMySql.Repositories.Interfaces
{
    public interface IOrganizacaoMySqlRepository
    {
        OrganizacaoMySql Obter();
        IEnumerable<OrganizacaoMySql> ListarTodos();
        Task<IEnumerable<OrganizacaoUsuarioMySql>> ListarOrganizacoesUsuarioEmail(string email);
    }
}