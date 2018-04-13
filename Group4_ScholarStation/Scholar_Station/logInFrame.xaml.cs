using System.Windows;
using System.Windows.Controls;
using ScholarStation;
using System.Text.RegularExpressions;

namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for logInFrame.xaml
    /// </summary>
    public partial class logInFrame : Page
    {
        private IUserFactory user;
        public logInFrame()
        {
            InitializeComponent();
            userSelectBox.Items.Add("Tutor");
            userSelectBox.Items.Add("Student");
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            inputValidationCheck();
        }

      public void inputValidationCheck()
        {
            if (Regex.IsMatch(emailBox.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
           {
                user = new UserFactory();
                User newUser = user.CreateUser("name", 1, UserType.Standard, emailBox.Text);

                if (emailBox.Text != null)
                {

                    this.NavigationService.Navigate(new LandingPage(newUser));
                }
            }
            else
            {
               MessageBox.Show("You Must Enter a vaild Email!");
            }
        }
    }
}
