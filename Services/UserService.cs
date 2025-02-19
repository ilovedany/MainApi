using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using System.Xml;
namespace MainAPI.Services
{
    public class UserService : IUserService
    {

        private readonly string _connectionString;

        public UserService(string connectionString){

            _connectionString = connectionString;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            using (var db = new NpgsqlConnection(_connectionString))
            {
                var users = await db.QueryAsync<User>("SELECT Id, Name, Surname, Age, Email, XamlData FROM Users");
                return users.ToList();
            }
        }
        public void AddUser(User user){
            using (var db = new NpgsqlConnection(_connectionString)){
                var sqlQuery = "INSERT INTO Users (Name,Surname,Age,Email) VALUES(@Name, @Surname, @Age, @Email) RETURNING Id;";

                int userId = db.Query<int>(sqlQuery,user).FirstOrDefault();

                user.Id = userId;
                
            }
        }
        public void DeleteUser(int id){
            using(var db = new NpgsqlConnection(_connectionString)){
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
        public void PutUser(User user){
            using(var db = new NpgsqlConnection(_connectionString)){
                var sqlQuery = "UPDATE Users SET Name = @Name, Surname = @Surname, Age = @Age, Email = @Email WHERE Id = @Id";
                db.Execute(sqlQuery,user);
            }
        }
        public string GetXml(int id){
            using(var db = new NpgsqlConnection(_connectionString)){
                var sqlQuery = db.Query<string>("SELECT GetXmlToId(@id)", new { id }).FirstOrDefault();
        
                return sqlQuery;
            }
        }
    }
}