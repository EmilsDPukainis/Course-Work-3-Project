using CourseWork3.Models;
using System.Data.SQLite;
using System.Windows;

namespace CourseWork3
{
    public partial class ServerSide : Window 
    {

        private ServerSideView _viewModel;


        private getJobs _userJobs;

        public ServerSideStatistics statistics;


        private SQLiteConnection connection = Database.GetConnection();
        public ServerSide()
        {

            InitializeComponent();
            _viewModel = new ServerSideView();
            DataContext = _viewModel;
            

            _userJobs = new getJobs();
            JobBox2.DataContext = _userJobs;

            JobLoader.LoadJobs(JobBox2);

        }






        private void addJob_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(addJobBox.Text))
            {
                ErrorMessage error = new ErrorMessage("New job space is empty.");
                error.Show();
            }
            else
            {

                using (var command = new SQLiteCommand(
                    "INSERT INTO jobs (job) VALUES ($job)", connection))
                {
                    command.Parameters.AddWithValue("$job", addJobBox.Text);
                    command.ExecuteNonQuery();
                }
                RefreshJobList();

                JobBox2.Items.Clear();
                JobBox2.Items.Add("Select a job");

                foreach (var job in _userJobs.GetJobs)
                {
                    JobBox2.Items.Add(job.Jobs);
                }
                addJobBox.Clear();
                JobBox2.SelectedIndex = 0;

            }
        }

        public void RefreshDataGrid()
        {
            _viewModel.GetNewUserLogins();
        }
        public void RefreshJobList()
        {
            _userJobs.GetUserJobs();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM checkIns; DELETE FROM users;";
                command.ExecuteNonQuery();
            }
            RefreshDataGrid();

        }

        private void Reset_Jobs_Click(object sender, RoutedEventArgs e)
        {
            int maxSize = 11;

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM jobs WHERE id > @maxSize";
                    command.Parameters.AddWithValue("@maxSize", maxSize);

                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            RefreshJobList();

            JobBox2.Items.Clear();
            JobBox2.Items.Add("Select a job");

            foreach (var job in _userJobs.GetJobs)
            {
                JobBox2.Items.Add(job.Jobs);
            }
            addJobBox.Clear();
            JobBox2.SelectedIndex = 0;

        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            statistics = new ServerSideStatistics();


            statistics.Show();
        }
    }
}
