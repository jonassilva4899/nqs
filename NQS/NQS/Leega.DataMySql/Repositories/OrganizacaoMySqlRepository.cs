using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leega.DataMySql.Entity;
using Leega.DataMySql.Repositories.Interfaces;

namespace Leega.DataMySql.Repositories
{
    public class OrganizacaoMySqlRepository : BaseMySqlRepository<OrganizacaoMySql>, IOrganizacaoMySqlRepository
    {
        public IEnumerable<OrganizacaoMySql> ListarTodos()
        {
            string sql = @"select * from organizacoes";
            return base.Listar<OrganizacaoMySql>(sql);
        }

        public OrganizacaoMySql Obter()
        {
            string sql = @"select * from organizacoes";
            return base.Obter<OrganizacaoMySql>(sql);
        }

        public async Task<IEnumerable<OrganizacaoUsuarioMySql>> ListarOrganizacoesUsuarioEmail(string email)
        {
            // buscar usuário
            string sql = @"select * from nqs.usuarios where Login = @Login;";
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object> { { "@Login", email } };
            UsuarioMySql usuarioMySql = base.Obter<UsuarioMySql>(sql, keyValuePairs);
            if (usuarioMySql == null)
            {
                return null;
            }

            // buscar organizações
            sql = @"select * from nqs.organizacaousuarios where IdUsuario = @IdUsuario;";
            keyValuePairs = new Dictionary<string, object> { { "@IdUsuario", usuarioMySql.Id } };
            IEnumerable<OrganizacaoUsuarioMySql> organizacaoUsuarioMySqls = await base.ListarPorAsync<OrganizacaoUsuarioMySql>(sql, keyValuePairs).ConfigureAwait(true);
            foreach (var item in organizacaoUsuarioMySqls)
            {
                item.Usuario = usuarioMySql;
            }

            return organizacaoUsuarioMySqls;
        }
    }
}
