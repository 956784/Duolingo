using System.Data.SqlClient;

namespace LanguageLearningApp
{
    public static class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=LanguageLearningApp;Integrated Security=True");
        }
    }
}