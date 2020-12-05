using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using Dapper;
using System.Threading.Tasks;

namespace Leega.DataMySql.Repositories
{
    public class BaseMySqlRepository<T> where T : class
    {
        protected readonly IDbConnection _dbConnection;
        public BaseMySqlRepository()
        {
            _dbConnection = new MySqlConnection(ConfigurationManager.AppSettings["_dbConnectionMySql"]);
        }

        protected IEnumerable<TClass> Listar<TClass>(string sql, T objeto) where TClass : class
        {
            return _dbConnection.Query<TClass>(sql, objeto);
        }

        protected IEnumerable<TClass> Listar<TClass>(string sql) where TClass : class
        {
            return _dbConnection.Query<TClass>(sql);
        }

        protected IEnumerable<T> Listar(string sql, Dictionary<string, object> objeto)
        {
            return _dbConnection.Query<T>(sql, objeto);
        }

        protected async Task<IEnumerable<T>> ListarAsync(string sql, T objeto)
        {
            return await _dbConnection.QueryAsync<T>(sql, objeto);
        }

        protected async Task<IEnumerable<TClass>> ListarPorAsync<TClass>(string sql, Dictionary<string, object> objeto) where TClass : class
        {
            return await _dbConnection.QueryAsync<TClass>(sql, objeto);
        }

        protected IEnumerable<TClass> Listar<TClass>(string sql, Dictionary<string, object> objeto) where TClass : class
        {
            return _dbConnection.Query<TClass>(sql, objeto);
        }

        protected T Obter(string sql, T objeto)
        {
            return _dbConnection.QueryFirstOrDefault<T>(sql, objeto);
        }

        protected TClass Obter<TClass>(string sql, Dictionary<string, object> objeto) where TClass : class
        {
            return _dbConnection.QueryFirstOrDefault<TClass>(sql, objeto);
        }

        protected TClass Obter<TClass>(string sql) where TClass : class
        {
            return _dbConnection.QueryFirstOrDefault<TClass>(sql);
        }

        protected T Obter(string sql, Dictionary<string, object> objeto)
        {
            return _dbConnection.QueryFirstOrDefault<T>(sql, objeto);
        }

        protected async Task<T> ObterAsync(string sql, T objeto)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<T>(sql, objeto);
        }

        protected async Task<T> ObterAsync(string sql, Dictionary<string, object> objeto)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<T>(sql, objeto);
        }

        protected void Adicionar(string sql, T objeto)
        {
            _dbConnection.ExecuteScalar(sql, objeto);
        }

        protected async Task AdicionarAsync(string sql, T objeto)
        {
            await _dbConnection.ExecuteScalarAsync(sql, objeto);
        }

        protected void Atualizar(string sql, T objeto)
        {
            _dbConnection.ExecuteScalar(sql, objeto);
        }

        protected async Task AtualizarAsync(string sql, T objeto)
        {
            await _dbConnection.ExecuteScalarAsync(sql, objeto);
        }

        protected void Remover(string sql, T objeto)
        {
            _dbConnection.ExecuteScalar(sql, objeto);
        }

        protected async Task RemoverAsync(string sql, T objeto)
        {
            await _dbConnection.ExecuteScalarAsync(sql, objeto);
        }
    }
}
