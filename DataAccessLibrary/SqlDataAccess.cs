using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace DataAccessLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        private readonly IJSRuntime _JsRuntime;
        public string ConnectionStringName { get; set; } = "DefaultConnection";
        public SqlDataAccess(IConfiguration config, IJSRuntime JsRuntime)
        {
            _config = config;
            _JsRuntime = JsRuntime;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            //Does not work with stored procs. Just reading sql statements
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }

        public async Task<T> LoadDataObject<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            //Does not work with stored procs. Just reading sql statements
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryFirstAsync<T>(sql, parameters);

                return data;
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            //Does not work with stored procs. Just reading sql statements
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
