using System.Windows;

namespace CourseWork3
{
    /// <summary>
    /// Interaction logic for NewCode.xaml
    /// </summary>
    public partial class NewCode : Window
    {
        public NewCode(string Code)
        {
            InitializeComponent();
            NewCodeBox.Text = Code;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
