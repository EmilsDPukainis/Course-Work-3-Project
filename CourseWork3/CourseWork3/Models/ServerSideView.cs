using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;

namespace CourseWork3.Models
{
    



    public class ServerSideView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<UserLogin> _newUserLogins;

        public ObservableCollection<UserLogin> NewUserLogins
        {
            get { return _newUserLogins; }
            set
            {
                _newUserLogins = value;
                OnPropertyChanged(nameof(NewUserLogins));
            }
        }

        public void GetNewUserLogins()
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();
                var command = new SQLiteCommand(
                    "SELECT users.id AS userId, users.name, users.surname, users.job, users.code, " +
                    "checkIns.checkedIn, checkIns.timeEntered, checkIns.dateEntered " +
                    "FROM users " +
                    "LEFT JOIN checkIns ON users.id = checkIns.userId ORDER BY checkIns.userId ASC, checkIns.dateEntered ASC", connection);
                var reader = command.ExecuteReader();

                var newUserLogins = new ObservableCollection<UserLogin>();
                while (reader.Read())
                {
                    var userLogin = new UserLogin()
                    {
                        Id = reader.IsDBNull(reader.GetOrdinal("userId")) ? 0 : reader.GetInt32(reader.GetOrdinal("userId")),
                        Name = reader.IsDBNull(reader.GetOrdinal("name")) ? string.Empty : (string)reader["name"],
                        Surname = reader.IsDBNull(reader.GetOrdinal("surname")) ? string.Empty : (string)reader["surname"],
                        Job = reader.IsDBNull(reader.GetOrdinal("job")) ? string.Empty : (string)reader["job"],
                        Code = reader.IsDBNull(reader.GetOrdinal("code")) ? string.Empty : (string)reader["code"],
                        Time = reader.IsDBNull(reader.GetOrdinal("timeEntered")) ? string.Empty : (string)reader["timeEntered"],
                        Date = reader.IsDBNull(reader.GetOrdinal("dateEntered")) ? string.Empty : (string)reader["dateEntered"],
                        CheckedIn = reader.IsDBNull(reader.GetOrdinal("checkedIn")) ? 0 : Convert.ToInt32(reader["checkedIn"])
                    };
                    newUserLogins.Add(userLogin);
                }
                reader.Close();

                NewUserLogins = newUserLogins;
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
