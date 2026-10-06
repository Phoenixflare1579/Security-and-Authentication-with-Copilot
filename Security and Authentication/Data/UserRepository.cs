using MySql.Data.MySqlClient;
using SafeVault.Models;

namespace SafeVault.Data
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User GetUserByUsername(string username)
        {
            const string query =
                @"SELECT UserID,
                         Username,
                         Email,
                         PasswordHash,
                         Role
                  FROM Users
                  WHERE Username = @Username";

            using var connection =
                new MySqlConnection(_connectionString);

            using var command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@Username",
                username);

            connection.Open();

            using var reader =
                command.ExecuteReader();

            if (reader.Read())
            {
                return new User
                {
                    UserID = reader.GetInt32("UserID"),
                    Username = reader.GetString("Username"),
                    Email = reader.GetString("Email"),
                    PasswordHash = reader.GetString("PasswordHash"),
                    Role = reader.GetString("Role")
                };
            }

            return null;
        }
    }
}