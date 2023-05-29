using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
using System.Globalization;

namespace CourseWork3.Models
{
    public class LoadUserStatistics : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<UserStatistics> _userData;

        public ObservableCollection<UserStatistics> UserData
        {
            get { return _userData; }
            set
            {
                _userData = value;
                OnPropertyChanged(nameof(UserData));
            }

        }

        public void LoadWorkerData()
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT users.name, users.surname, checkIns.dateEntered, checkIns.userId, checkIns.timeEntered, checkIns.checkedIn FROM checkIns JOIN users ON checkIns.userId = users.Id ORDER BY checkIns.dateEntered ASC", connection);
                var reader = command.ExecuteReader();
                // ---
                var list = new List<UserStatistics>();

                while (reader.Read())
                {
                    var userData = new UserStatistics()
                    {
                        Name = reader.IsDBNull(reader.GetOrdinal("name")) ? string.Empty : (string)reader["name"],
                        Surname = reader.IsDBNull(reader.GetOrdinal("surname")) ? string.Empty : (string)reader["surname"],
                        CheckedIn = reader.IsDBNull(reader.GetOrdinal("checkedIn")) ? 0 : Convert.ToInt32(reader["checkedIn"]),
                        Date = reader.IsDBNull(reader.GetOrdinal("dateEntered")) ? string.Empty : (string)reader["dateEntered"],
                        UserID = reader.IsDBNull(reader.GetOrdinal("userId")) ? string.Empty : "" + reader["userId"],

                    };
                    if (userData.CheckedIn == 1)
                    {
                        userData.TimeEntered = reader.IsDBNull(reader.GetOrdinal("timeEntered")) ? string.Empty : (string)reader["timeEntered"];
                    }
                    else
                    {
                        userData.TimeExited = reader.IsDBNull(reader.GetOrdinal("timeEntered")) ? string.Empty : (string)reader["timeEntered"];

                    }

                    list.Add(userData);
                }
                for (var i = 1; i < list.Count; i++)
                {
                    if (list[i].CheckedIn == 0)
                    {
                        var j = i - 1;
                        for (; j >= 0; j--)
                        {
                            if (list[j].CheckedIn == 1 && list[j].UserID == list[i].UserID)
                            {
                                list[j].TimeExited = list[i].TimeExited;
                                list.RemoveAt(i);
                                i--;
                                break;
                            }
                        }


                    }
                }

                // ---
                var UserStats = new ObservableCollection<UserStatistics>();

                foreach (var userData in list)
                {

                    // User has exited, set timeExited to the current time
                    DateTime exited = DateTime.Now;
                    DateTime entered = DateTime.ParseExact(userData.TimeEntered, "t", CultureInfo.InvariantCulture);
                    if (!string.IsNullOrEmpty(userData.TimeExited))
                    {
                        exited = DateTime.ParseExact(userData.TimeExited, "t", CultureInfo.InvariantCulture);

                    }

                    double totalHours = (exited - entered).TotalHours;
                    userData.TotalHours = totalHours.ToString("F1"); // Convert the double to string

                    if (totalHours < 8)
                    {
                        userData.Status = "Underworking";
                    }
                    else if (totalHours > 9)
                    {
                        userData.Status = "Overworking";
                    }
                    else
                    {
                        userData.Status = "Normal";
                    }


                    UserStats.Add(userData);
                }
                reader.Close();




                UserData = UserStats;
            }

        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
