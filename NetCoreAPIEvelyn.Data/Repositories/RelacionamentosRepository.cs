using Dapper;
using MySql.Data.MySqlClient;
using NetCoreAPIEvelyn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIEvelyn.Data.Repositories
{
    public class RelacionamentosRepository : IRelacionamentosRepository
    {
        private MySQLConfiguration _connectionString;
        public RelacionamentosRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<relacionamentos>> GetRelacionamentos()
        {
            var db = dbConnection();

            var sql = @"
                        select idconjuge, conjuge, termino, nomemarido
                          from tbrelacionamentos  ";

            return await db.QueryAsync<relacionamentos>(sql, new { });
        }

        public async Task<relacionamentos> GetRelacionamentosDetails(int id)
        {
            var db = dbConnection();

            var sql = @"
                        select idconjuge, conjuge, termino, nomemarido
                          FROM tbrelacionamentos
                          WHERE id = @";

            return await db.QueryFirstOrDefaultAsync<relacionamentos>(sql, new { idconjuge = id });
        }

        public async Task<bool> InsertRelacionamentos(relacionamentos relacionamentos)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO tbrelacionamentos (idconjuge, conjuge, termino, nomemarido)
                        VALUES (@idconjuge, @Conjuge, @Termino, @Nomemarido)";

            var result = await db.ExecuteAsync(sql, new { relacionamentos.idconjuge, relacionamentos.conjuge, relacionamentos.termino, relacionamentos.nomemarido });

            return result > 0;
        }

        public async Task<bool> UpdateRelacionamentos(relacionamentos relacionamentos)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE tbrelacionamentos 
                        SET conjuge = @Conjuge, termino = @Termino, nomemarido = @Nomemarido
                           WHERE idconjuge = @idcojuge";


            var result = await db.ExecuteAsync(sql, new { relacionamentos.conjuge, relacionamentos.termino, relacionamentos.nomemarido, relacionamentos.idconjuge });

            return result > 0;
        }


        public async Task<bool> DeleteRelacionamentos(relacionamentos relacionamentos)
        {
            var db = dbConnection();

            var sql = @"
                        DELETE 
                          FROM tbrelacionamentos 
                          WHERE idconjuge = @idconjuge";

            var result = await db.ExecuteAsync(sql, new { idconjuge = relacionamentos.idconjuge });
            return result > 0;
        }
    }
}
