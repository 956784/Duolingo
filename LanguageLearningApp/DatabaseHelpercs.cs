using System;
using System.Configuration; // Для доступа к файлу конфигурации
using System.Data;
using System.Data.SqlClient;

namespace LanguageLearningApp
{
    // Класс для работы с текущим пользователем
    public static class CurrentUser
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static bool IsAdmin { get; set; }
    }

    // Вспомогательный класс для работы с базой данных
    public static class DatabaseHelper
    {
        private static readonly string connectionString;

        static DatabaseHelper()
        {
            // Получение строки подключения из файла конфигурации
            if (ConfigurationManager.ConnectionStrings["LanguageLearningDB"] == null)
            {
                throw new ConfigurationErrorsException("Connection string 'LanguageLearningDB' not found in configuration file.");
            }

            connectionString = ConfigurationManager.ConnectionStrings["LanguageLearningDB"].ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ConfigurationErrorsException("Connection string 'LanguageLearningDB' is empty.");
            }
        }

        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
            return connection;
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Query cannot be null or empty.", nameof(query));
            }

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Error executing query", ex);
            }
            return dt;
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Query cannot be null or empty.", nameof(query));
            }

            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Error executing non-query command", ex);
            }
        }

        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Query cannot be null or empty.", nameof(query));
            }

            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Error executing scalar command", ex);
            }
        }

        // Новый метод для выполнения вставки с возвратом идентификатора
        public static int ExecuteNonQueryWithIdentity(string query, SqlParameter[] parameters = null)
        {
            string queryWithIdentity = query + "; SELECT SCOPE_IDENTITY();";
            object result = ExecuteScalar(queryWithIdentity, parameters);
            return Convert.ToInt32(result);
        }
    }
}
