using Leega.DataMySql.Entity;
using Leega.DataMySql.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leega.DataMySql.Repositories
{
    public class UsuarioMySqlRepository : BaseMySqlRepository<UsuarioMySql>, IUsuarioMySqlRepository
    {
        public void Adicionar(UsuarioMySql obj)
        {
            string sql = @"insert into usuarios (
                                Id, Login, Senha, DataCriacao, DataEdicao, ResponsavelCriacao, ResponsavelEdicao, Ativo, ContaGoogle
                            ) values (
                                @Id, @Login, @Senha, @DataCriacao, @DataEdicao, @ResponsavelCriacao, @ResponsavelEdicao, @Ativo, @ContaGoogle
                            );";

            base.Adicionar(sql, obj);
        }

        public UsuarioMySql ObterUsuarioLogin(UsuarioMySql objeto)
        {
            // busca usuarios
            string sql = @"select * from nqs.usuarios where Login = @Login;";
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object> { { "Login", objeto.Login } };
            UsuarioMySql usuarioMySql = base.Obter(sql, keyValuePairs);
            if (usuarioMySql == null)
            {
                return null;
            }

            // busca organizações usuario
            sql = @"select * from nqs.organizacaousuarios where IdUsuario = @IdUsuario;";
            keyValuePairs = new Dictionary<string, object> { { "IdUsuario", usuarioMySql.Id } };
            IEnumerable<OrganizacaoUsuarioMySql> organizacaoUsuarioMySqls = base.Listar<OrganizacaoUsuarioMySql>(sql, keyValuePairs);

            // buscar roles
            if (organizacaoUsuarioMySqls != null)
            {
                usuarioMySql.Organizacoes = organizacaoUsuarioMySqls?.ToList();
                foreach (var item in usuarioMySql.Organizacoes)
                {
                    sql = @"select * from nqs.organizacaousuarioroles where Id = @Id;";
                    keyValuePairs = new Dictionary<string, object> { { "Id", item.IdOrganizacaoUsuarioRole } };
                    OrganizacaoUsuarioRoleMySql organizacaoUsuarioRoleMySqls = base.Obter<OrganizacaoUsuarioRoleMySql>(sql, keyValuePairs);
                    item.OrganizacaoUsuarioRole = organizacaoUsuarioRoleMySqls;
                }
            }

            return usuarioMySql;
        }

        public async Task<UsuarioMySql> ObterUsuarioAsync(UsuarioMySql objeto)
        {
            string sql = @"select * from nqs.usuarios";
            return await base.ObterAsync(sql, objeto);
            //return await _appContext.Usuarios
            //    .SingleOrDefaultAsync(predicate);
        }
    }
}
