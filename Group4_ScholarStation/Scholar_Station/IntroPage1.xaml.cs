using System.Windows;
using System.Windows.Controls;
using ScholarStation;

namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for IntroPage1.xaml
    /// </summary>
    public partial class IntroPage1 : Page
    {
        public IntroPage1()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new logInFrame());
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            User user = null;
            SessionFinder finder = new SessionFinder(user);
            finder.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
