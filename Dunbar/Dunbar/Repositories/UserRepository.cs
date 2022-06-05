using Dunbar.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Dunbar.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public List<User> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Select Name, UserName, Email, Id
                                        FROM Users";

                    using (var reader = cmd.ExecuteReader())
                    {
                        var uzrs = new List<User>();

                        while (reader.Read())
                        {
                            uzrs.Add(new User()
                            {
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Id = reader.GetInt32(reader.GetOrdinal("Id"))
                            });
                        }

                        return uzrs;
                    }

                }
            }
        }
    }
}
