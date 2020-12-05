using Leega.DataMySql.Entity;
using Leega.DataMySql.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Repositories
{
    public class EquipamentoMySqlRepository : BaseMySqlRepository<EquipamentoMySql>, IEquipamentoMySqlRepository
    {

        public void Adicionar(EquipamentoMySql obj)
        {
            string sql = @"insert into clientes (
                                    Id, Nome, DataCriacao, ResponsavelCriacao, DataEdicao, ResponsavelEdicao, IdOrganizacao
                                ) values (
                                    @Id, @Nome, @DataCriacao, @ResponsavelCriacao, @DataEdicao, @ResponsavelEdicao, @IdOrganizacao
                                );";

            base.Adicionar(sql, obj);
        }
    }
}

