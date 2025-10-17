using System;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WinFormsApp2
{
    public static class Database
    {
        private static string dbFile = "users.db";
        private static string connectionString = $"Data Source={dbFile};Version=3;";

        public static void Init()
        {
            bool createTable = !File.Exists(dbFile);

            if (createTable)
                SQLiteConnection.CreateFile(dbFile);

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS Users (
                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                username TEXT NOT NULL UNIQUE,
                                email TEXT NOT NULL UNIQUE,
                                password TEXT NOT NULL
                               );";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool UserExists(string email)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(1) FROM Users WHERE email=@Email";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static bool UsernameExists(string username)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(1) FROM Users WHERE username=@Username";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static void AddUser(string username, string email, string password)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Users (username, email, password) VALUES (@Username, @Email, @Password)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", HashPassword(password));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool ValidateUser(string email, string password)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT password FROM Users WHERE email=@Email";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    var result = cmd.ExecuteScalar();
                    if (result == null) return false;

                    string storedHash = result.ToString();
                    string enteredHash = HashPassword(password);
                    return storedHash == enteredHash;
                }
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        internal static bool ValidatePassword(string email, string hashedInput)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT password FROM Users WHERE email=@Email";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    var result = cmd.ExecuteScalar();
                    if (result == null) return false;

                    string storedHash = result.ToString();
                    return storedHash == hashedInput;
                }
            }
        }
    }
}
