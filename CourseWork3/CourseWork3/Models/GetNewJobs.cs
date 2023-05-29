using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;

namespace CourseWork3.Models
{
    public class getJobs : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<UserLogin> _getJobs;

        public ObservableCollection<UserLogin> GetJobs
        {
            get { return _getJobs; }
            set
            {
                _getJobs = value;
                OnPropertyChanged(nameof(GetJobs));
            }
        }

        public void GetUserJobs()
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();
                var command = new SQLiteCommand(
                    "SELECT job FROM jobs ", connection);
                var reader = command.ExecuteReader();

                var UserJobs = new ObservableCollection<UserLogin>();
                while (reader.Read())
                {
                    var userLogin = new UserLogin()
                    {
                        Jobs = (string)reader["job"],

                    };
                    UserJobs.Add(userLogin);
                }
                reader.Close();

                GetJobs = UserJobs;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
