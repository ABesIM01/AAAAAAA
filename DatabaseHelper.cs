using System;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public static class DatabaseHelper
    {
        private static readonly string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.db");
        private static readonly string connectionString = $"Data Source={dbPath};Version=3;";

        static DatabaseHelper()
        {
            try
            {
                if (!File.Exists(dbPath))
                {
                    SQLiteConnection.CreateFile(dbPath);
                }

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"CREATE TABLE IF NOT EXISTS users (
                                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    username TEXT UNIQUE NOT NULL,
                                    password TEXT NOT NULL,
                                    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                                   );";
                    new SQLiteCommand(sql, conn).ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database initialization error: {ex.Message}", "DB Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================
        // Реєстрація користувача
        // ==========================
        public static bool RegisterUser(string username, string password)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO users (username, password) VALUES (@u, @p)";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                if (ex.ResultCode == SQLiteErrorCode.Constraint)
                    MessageBox.Show("Користувач із таким логіном уже існує.", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show($"Помилка бази даних: {ex.Message}", "DB Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ==========================
        // Авторизація користувача
        // ==========================
        public static bool ValidateUser(string username, string password)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM users WHERE username=@u AND password=@p";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

    }
}
        // ==========================
        // Хешування пароля
        // ==========================