using System.Windows;

namespace CourseWork3
{
    /// <summary>
    /// Interaction logic for ThankYouMessage.xaml
    /// </summary>
    public partial class ThankYouMessage : Window
    {
        public ThankYouMessage(string thankYouMessage)
        {

            InitializeComponent();
            thankyouMessage.Text = thankYouMessage;

        }
    }
}
