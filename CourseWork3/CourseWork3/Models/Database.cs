using System.Data.SQLite;

namespace CourseWork3.Models
{
    public static class Database
    {
        private static SQLiteConnection connection;

        public static SQLiteConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new SQLiteConnection("Data Source=database.db");
                connection.Open();
            }
            return connection;
        }
    }
}
