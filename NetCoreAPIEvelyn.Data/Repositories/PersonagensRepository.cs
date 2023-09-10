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
    public class PersonagensRepository : IPersonagensRepository

    {
        private MySQLConfiguration _connectionString;
        public PersonagensRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

       

        public  async Task<IEnumerable<personagens>> GetAllPersonagens()
        {
            var db = dbConnection();

            var sql = @"
                        select idpersona, nomepersona, historia, adicionais
                          from tbpersonagens  ";

            return await db.QueryAsync<personagens>(sql, new { });
        }

        public async Task<personagens> GetPersonagensDetails(int id)
        {
            var db = dbConnection();

            var sql = @"
                        select idpersona, nomepersona, historia, adicionais
                          FROM tbpersonagens 
                          WHERE id = @";

            return await db.QueryFirstOrDefaultAsync<personagens>(sql, new {idpersona = id });
        }

        public async Task<bool> InsertPersonagens(personagens personagens)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO tbpersonagens (idpersona, nomepersona, historia, adicionais)
                        VALUES (@idpersona, @Nomepersona, @Historia, @Adicionais)";

            var result = await db.ExecuteAsync(sql, new {personagens.idpersona, personagens.nomepersona, personagens.historia, personagens.adicionais });

            return result > 0;
        }

        public async Task<bool> UpdatePersonagens(personagens personagens)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE tbpersonagens 
                        SET nomepersona = @Nomepersona, historia = @Historia, adicionais = @Adicionais
                           WHERE idpersona = @idpersona";
                      

            var result = await db.ExecuteAsync(sql, new { personagens.nomepersona, personagens.historia, personagens.adicionais, personagens.idpersona});

            return result > 0;
        }

        public async Task<bool> DeletePersonagens(personagens personagens)
        {
            var db = dbConnection();

            var sql = @"
                        DELETE 
                          FROM tbpersonagens 
                          WHERE idpersona = @idpersona";

            var result = await db.ExecuteAsync(sql, new { idpersona = personagens.idpersona });
            return result > 0;
        }
    }
}
