using CourseWork3.Models;
using System;
using System.Data.SQLite;
using System.Windows;

namespace CourseWork3
{
    public partial class MainWindow : Window
    {
        private SQLiteConnection connection = Database.GetConnection(); // Make the Datavase.cs model usable
        private ServerSide server; // Declare the ServerSide object as a field


        public MainWindow()
        {


            InitializeComponent();


            using (var command = new SQLiteCommand(
                "BEGIN;" +

                // Create the "users" table if it doesn't exist
                @"CREATE TABLE IF NOT EXISTS users (
                    id INTEGER PRIMARY KEY,
                    name TEXT NOT NULL,
                    surname TEXT NOT NULL,
                    job TEXT NOT NULL,
                    code TEXT NOT NULL UNIQUE);" +

                // Create the "jobs" table if it doesn't exist
                @"CREATE TABLE IF NOT EXISTS jobs (  
                    id INTEGER PRIMARY KEY,
                    job TEXT);" +

                // Create the "checkIns" table if it doesn't exist
                @"CREATE TABLE IF NOT EXISTS checkIns (
                    id INTEGER PRIMARY KEY,
                    userId INTEGER NOT NULL,
                    checkedIn INTEGER,
                    timeEntered TEXT,
                    dateEntered TEXT,
                    FOREIGN KEY (userId) REFERENCES users(id));" +
                    "COMMIT;", connection))
            {
                command.ExecuteNonQuery(); //Execute command
            }



            using (var command = new SQLiteCommand("SELECT COUNT(*) FROM jobs", connection)) //creates jobs
            {
                
                    var count = Convert.ToInt32(command.ExecuteScalar());
                    if (count == 0)
                    {
                        // Insert jobs
                        using (var command2 = new SQLiteCommand(
                            @"INSERT INTO jobs (job) VALUES ('Software Developer'), ('Web Developer'), ('DevOps Engineer'), ('Systems Analyst'), ('Network Engineer'), ('Project Manager'), ('Data Analyst'), ('IT Support'), ('Graphic Designer'), ('IT Trainer'), ('Security Analyst')",
                            connection))
                        {
                            command2.ExecuteNonQuery();
                        }
                    }
                
            }
            server = new ServerSide();
            server.RefreshDataGrid();
            server.Show();

        }

        private void SubmitCodeButton_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                if (string.IsNullOrEmpty(CodeBox.Text)) //error if codebox is empty
                {
                    ErrorMessage error = new ErrorMessage("Please write a code");
                    error.Show();
                    return;
                }

                // Get user ID from the code entered
                var userId = 0;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT id FROM users WHERE code = $code";
                command.Parameters.AddWithValue("$code", CodeBox.Text);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userId = reader.GetInt32(0);
                    }
                    else
                    {
                        ErrorMessage error = new ErrorMessage("Looks like you've entered the wrong code.");
                        CodeBox.Clear();
                        error.Show();
                        return;
                    }
                }
                
                var previousLoginId = -1;
                var isChecked = true;
                command = connection.CreateCommand();
                command.CommandText = "SELECT id, checkedIn FROM checkIns WHERE userId = $userId ORDER BY id DESC LIMIT 1";
                command.Parameters.AddWithValue("$userId", userId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        previousLoginId = reader.GetInt32(0);
                        object checkedInValue = reader.GetValue(1);
                        if (!Convert.IsDBNull(checkedInValue))
                        {
                            isChecked = Convert.ToInt32(checkedInValue) == 0;
                        }
                    }
                }

                isChecked = !isChecked;  
                // Update the checked-in status

                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO checkIns(dateEntered, userId, timeEntered, checkedIn) VALUES ($dateEntered, $userId , $timeEntered, $isCheckedIn)";
                command.Parameters.AddWithValue("$isCheckedIn", isChecked ? 0 : 1);
                command.Parameters.AddWithValue("$loginId", previousLoginId);
                command.Parameters.AddWithValue("$userId", userId);
                command.Parameters.AddWithValue("$dateEntered", DateTime.Today.ToString("dd-MM-yyyy"));
                command.Parameters.AddWithValue("$timeEntered", DateTime.Now.ToString("t"));
                command.ExecuteNonQuery();

                // Refresh the data grid in the ServerSide window
                server.RefreshDataGrid();

                // Show the appropriate message based on the checked-in status
                if (isChecked)
                {
                    ThankYouMessage Thanks = new ThankYouMessage("You're Checked Out");
                    Thanks.Show();
                }
                else
                {
                    ThankYouMessage Thanks = new ThankYouMessage("You're Checked In");
                    Thanks.Show();
                }
            }

            CodeBox.Clear();
        }

        private void RegistrationWindow_Closed(object sender, EventArgs e)
        {
            // re-enable the button when the window is closed
            RegisterLink.IsEnabled = true;
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterLink.IsEnabled = false;
            // create and show the window
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Owner = this;
            registrationWindow.Server = server; // Pass the reference to the ServerSide window
            registrationWindow.Closed += RegistrationWindow_Closed; // attach the event handler
            registrationWindow.Show();


        }




    }
}
