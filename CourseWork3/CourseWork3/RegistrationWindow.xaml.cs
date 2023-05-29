using CourseWork3.Models;
using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace CourseWork3
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    /// 

    public partial class RegistrationWindow : Window
    {

        public ServerSide Server;
        public RegistrationWindow()
        {
            InitializeComponent();
            JobLoader.LoadJobs(JobBox); //Assign fetched jobs to jobbox

        }
        private SQLiteConnection connection = Database.GetConnection();


        private void Register_Click(object sender, RoutedEventArgs e)
        {
            //checke if everything is filled out
            if (string.IsNullOrWhiteSpace(FirstNameBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameBox.Text) ||
                JobBox.SelectedItem == null || (JobBox.SelectedItem is ComboBoxItem && (JobBox.SelectedItem as ComboBoxItem).Content.ToString() == "Select a job"))
            {
                ErrorMessage error = new ErrorMessage("Please fill in all required fields.");
                error.Show();
                return;
            }
            else
            {
                var random = new Random();
                var Code = random.Next(1000, 10000).ToString();
                using (var command = new SQLiteCommand(
                    "INSERT INTO users (name, surname, job, code) VALUES ($name, $surname, $job, $Code)", connection))
                {
                    command.Parameters.AddWithValue("$name", FirstNameBox.Text);
                    command.Parameters.AddWithValue("$surname", LastNameBox.Text);
                    command.Parameters.AddWithValue("$job", JobBox.Text);
                    command.Parameters.AddWithValue("$Code", Code);
                    command.ExecuteNonQuery();
                }
                Server.RefreshDataGrid();
                NewCode code = new NewCode(Code);
                code.Show();

                FirstNameBox.Clear();
                LastNameBox.Clear();
                Close();
            }
        }
    }
}
