using CourseWork3.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace CourseWork3
{

    public partial class ServerSideStatistics : Window
    {

        public LoadUserStatistics _LoadUsers;

        public ServerSideStatistics()
        {
            InitializeComponent();

            _LoadUsers = new LoadUserStatistics();
            DataContext = _LoadUsers;
            RefreshStatisticsDataGrid();

            StatisticGrid2.ItemsSource = null;
            if (_LoadUsers.UserData != null)
            {
            var uniqueUsers = _LoadUsers.UserData
            .GroupBy(user => user.FullName)
            .Select(group => group.First());

        // Set the unique users as the ItemsSource for StatisticGrid1
            StatisticGrid1.ItemsSource = uniqueUsers;

            }

            // Set the unique users as the ItemsSource for StatisticGrid1
            RefreshStatisticsDataGrid();
        }

        private void SelectWorker_Click(object sender, RoutedEventArgs e)
        {

            var selectedUser = ((Button)sender).DataContext as UserStatistics;

            // Filter and set the ItemsSource for StatisticGrid2 based on the selected user
            var filteredUserData = new ObservableCollection<UserStatistics>(
                _LoadUsers.UserData.Where(user => user.FullName == selectedUser.FullName)
            );

            StatisticGrid2.ItemsSource = filteredUserData;
            RefreshStatisticsDataGrid();
        }

        public void RefreshStatisticsDataGrid()
        {
            _LoadUsers.LoadWorkerData();
        }

    }
}