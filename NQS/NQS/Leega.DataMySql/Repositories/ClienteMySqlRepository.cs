using Leega.DataMySql.Entity;
using Leega.DataMySql.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Repositories
{
    public class ClienteMySqlRepository : BaseMySqlRepository<ClienteMySql>, IClienteMySqlRepository
    {
        public IEnumerable<ClienteMySql> ListarTodos()
        {
            string sql = @"select * from clientes";
            return base.Listar<ClienteMySql>(sql);
        }

        public IEnumerable<ClienteMySql> ListarTodos(string idOrganizacao)
        {
            string sql = @"select * from clientes where idorganizacao = @IdOrganizacao";
            return base.Listar<ClienteMySql>(sql, new ClienteMySql { IdOrganizacao = idOrganizacao });
        }

        public ClienteMySql Obter(ClienteMySql obj)
        {
            string sql = @"select * from clientes where Id = @Id";
            return base.Obter(sql, obj);
        }

        public void Adicionar(ClienteMySql obj)
        {
            string sql = @"insert into clientes (
                                Id, Nome, DataCriacao, ResponsavelCriacao, DataEdicao, ResponsavelEdicao, IdOrganizacao
                            ) values (
                                @Id, @Nome, @DataCriacao, @ResponsavelCriacao, @DataEdicao, @ResponsavelEdicao, @IdOrganizacao
                            );";

            base.Adicionar(sql, obj);
        }

        public void Atualizar(ClienteMySql obj)
        {
            string sql = @"update clientes set 
                                Id = @Id, 
                                Nome = @Nome, 
                                DataEdicao = @DataEdicao, 
                                ResponsavelEdicao = @ResponsavelEdicao, 
                                IdOrganizacao = @IdOrganizacao
                            where Id = @Id;";

            base.Adicionar(sql, obj);
        }

        public void Remover(ClienteMySql obj)
        {
            string sql = @"delete from clientes where Id = @Id;";

            base.Remover(sql, obj);
        }
    }
}
