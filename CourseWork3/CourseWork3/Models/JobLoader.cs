using System.Data.SQLite;
using System.Windows.Controls;

namespace CourseWork3.Models
{
    public static class JobLoader
    {

        public static void LoadJobs(ComboBox jobBox)
        {

            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT job FROM jobs";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        jobBox.Items.Add(reader.GetString(0));
                    }
                }
            }
        }

    }
}