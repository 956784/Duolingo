using System;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Проверяем, есть ли администратор в системе
            if (!CheckAdminExists())
            {
                // Если нет, создаем администратора
                CreateAdminUser();
            }

            Application.Run(new LoginForm());
        }

        private static bool CheckAdminExists()
        {
            string query = "SELECT COUNT(*) FROM Users WHERE IsAdmin = 1";
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query));
            return count > 0;
        }

        private static void CreateAdminUser()
        {
            try
            {
                string query = @"IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'admin')
                         BEGIN
                             INSERT INTO Users (Username, Password, Email, IsAdmin)
                             VALUES ('admin', 'admin123', 'admin@example.com', 1)
                         END";
                DatabaseHelper.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании администратора: {ex.Message}");
            }
        }
    }
}

