
namespace CourseWork3.Models
{
    public class UserStatistics
    {
        
            //public static List<UserStatistics> UserDataList = new List<UserStatistics>();

            public string Name { get; set; }
            public string UserID { get; set; }
            public string Surname { get; set; }
            public string Date { get; set; }
            public string TimeEntered { get; set; }
            public string TimeExited { get; set; }
            public string TotalHours { get; set; }
            public int CheckedIn { get; set; }
            public string Status { get; set; }
            public string FullName => $"{Name} {Surname}";

        
    }
}
