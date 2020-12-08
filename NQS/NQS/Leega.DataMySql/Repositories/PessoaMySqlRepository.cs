using Leega.DataMySql.Entity;
using Leega.DataMySql.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leega.DataMySql.Repositories
{
    public class PessoaMySqlRepository : BaseMySqlRepository<PessoaMySql>, IPessoaMySqlRepository
    {
        public void Adicionar(PessoaMySql obj)
        {
            string sql = @"insert into pessoas (
                                Id, Nome, Foto, FuncaoPrincipal, Telefone, Email, Status, DataCriacao, ResponsavelCriacao, DataEdicao, ResponsavelEdicao, MiniBio, GoobeeAdmin, IdUltimaOrgAcessada
                            ) values (
                                @Id, @Nome, @Foto, @FuncaoPrincipal, @Telefone, @Email, @Status, @DataCriacao, @ResponsavelCriacao, @DataEdicao, @ResponsavelEdicao, @MiniBio, @GoobeeAdmin, @IdUltimaOrgAcessada
                            );";

            base.Adicionar(sql, obj);
        }

        //SELECT id, NomeCompleto, DocumentoIdentificacao, celular FROM nqs.paciente;

        public async Task<PessoaMySql> BuscarPorEmail(string email)
        {
            // buscar pessoas
            string sql = @"select * from pessoas where Email = @Email;";
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object> { { "@Email", email } };
            PessoaMySql pessoaMySql = await base.ObterAsync(sql, keyValuePairs);
            if (pessoaMySql == null)
            {
                return null;
            }

            // buscar organizaoes por pessoa
            sql = @"select * from organizacaousuarios where IdPessoa = @IdPessoa;";
            keyValuePairs = new Dictionary<string, object> { { "@IdPessoa", pessoaMySql.Id } };
            IEnumerable<OrganizacaoUsuarioMySql> organizacaoUsuarioMySqls = await base.ListarPorAsync<OrganizacaoUsuarioMySql>(sql, keyValuePairs);

            if (organizacaoUsuarioMySqls != null)
            {
                // pesquisa organizações
                pessoaMySql.Organizacoes = organizacaoUsuarioMySqls?.ToList();
                foreach (var item in pessoaMySql.Organizacoes)
                {
                    sql = @"select * from organizacoes where Id = @Id;";
                    keyValuePairs = new Dictionary<string, object> { { "@Id", item.IdOrganizacao } };
                    OrganizacaoMySql organizacaoMySqls = base.Obter<OrganizacaoMySql>(sql, keyValuePairs);
                    item.Organizacao = organizacaoMySqls;
                }
            }

            return pessoaMySql;
        }

        public IEnumerable<PessoaMySql> ListarTodas(string idOrganizacao)
        {
            string sql = @"";
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object> { { "idorganizacao", idOrganizacao } };
            return base.Listar(sql, keyValuePairs);
        }
    }
}
