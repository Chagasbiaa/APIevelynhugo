using Dapper;
using MySql.Data.MySqlClient;
using NetCoreAPIEvelyn.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIEvelyn.Data.Repositories
{
    public class AutoraRepository : IAutoraRepository
    {

        private MySQLConfiguration _connectionString;
        public AutoraRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<autora>> GetAllAutora()
        {
            var db = dbConnection();

            var sql = @"
                        select idautora, nomeautora, livros, biografia, premios
                          from tbautora  ";

            return await db.QueryAsync<autora>(sql, new { });
        }

        public async Task<autora> GetAutoraDetails(int id)
        {
            var db = dbConnection();

            var sql = @"
                        select idautora, nomeautora, livros, biografia, premios
                          FROM tbautora 
                          WHERE id = @";

            return await db.QueryFirstOrDefaultAsync<autora>(sql, new { idautora = id });
        }

        public async Task<bool> InsertAutora(autora autora)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO tbautora (idautora, nomeautora, livros, biografia, premios)
                        VALUES (@idautora, @Nomeautora, @Livros, @Biografia, @Premios)";

            var result = await db.ExecuteAsync(sql, new { autora.idautora, autora.nomeautora, autora.livros, autora.biografia, autora.premios });

            return result > 0;
        }

        public async Task<bool> UpdateAutora(autora autora)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE tbautora 
                        SET nomeautora = @Nomeautora, livros = @Livros, biografia = @Biogradia, premios = @Premios
                           WHERE idautora = @idautora";


            var result = await db.ExecuteAsync(sql, new { autora.nomeautora, autora.livros, autora.biografia, autora.premios, autora.idautora });

            return result > 0;
        }


        public async Task<bool> DeleteAutora(autora autora)
        {
            var db = dbConnection();

            var sql = @"
                        DELETE 
                          FROM tbautora
                          WHERE idautora = @idautora";

            var result = await db.ExecuteAsync(sql, new { idautora = autora.idautora });
            return result > 0;
        }

        Task<autora> IAutoraRepository.GetAutoraDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
