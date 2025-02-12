using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
namespace MainAPI.Services
{
    internal class SpecialistRankService : ISpecialistRankService
    {
        private readonly string _connectionString;

        public SpecialistRankService(string connectionString){

            _connectionString = connectionString;
        }
        public async Task<IEnumerable<SpecialistRank>> GetRankAsync()
        {
            using (var db = new NpgsqlConnection(_connectionString))
            {
                var user_adress = await db.QueryAsync<SpecialistRank>("SELECT Id_rank, Rank, Id FROM specialistrank");
                return user_adress.ToList();
            }
        }
        public void AddRank(SpecialistRank specialistRank)
        {
            using (var db = new NpgsqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO specialistrank (Rank,Id) VALUES(@Rank, @Id) RETURNING Id_rank;";

                int rankId = db.Query<int>(sqlQuery, specialistRank).FirstOrDefault();

                specialistRank.Id_rank = rankId;
            }
        }
        public void DeleteRank(int id_rank)
        {
            using (var db = new NpgsqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM specialistrank WHERE Id_rank = @id_rank";
                db.Execute(sqlQuery, new { id_rank });
            }
        }
        public void PutRank(SpecialistRank specialistRank)
        {
            using (var db = new NpgsqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE specialistrank SET Rank = @Rank, Id = @Id WHERE Id_rank = @Id_rank";
                db.Execute(sqlQuery, specialistRank);

            }
        }
        public IEnumerable<SpecialistRank> GetRankToID(int id)
        {
            using (var db = new NpgsqlConnection(_connectionString))
            {
                var sqlQuery = "SELECT * FROM specialistrank WHERE Id = @Id";
                
                return db.Query<SpecialistRank>(sqlQuery, new { Id = id });
                
            }
        }
    }
}
