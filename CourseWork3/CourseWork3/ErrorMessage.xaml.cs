using System.Windows;

namespace CourseWork3
{
    /// <summary>
    /// Interaction logic for ErrorMessage.xaml
    /// </summary>
    public partial class ErrorMessage : Window
    {
        public ErrorMessage(string errorMessage)
        {

            InitializeComponent();
            ErrorMessageTextBlock.Text = errorMessage;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
