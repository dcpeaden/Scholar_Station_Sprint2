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
                        if (userSelectBox.SelectedIndex == 1)
                        {
                           this.NavigationService.Navigate(new joinSessionFrame(newUser));
                        }
                        else if (userSelectBox.SelectedIndex == 0)
                        {
                           this.NavigationService.Navigate(new tutorPage(newUser));
                        }
                        else
                        {
                           MessageBox.Show("You must select a user type!");
                        }
                     }
            }
            else
            {
               MessageBox.Show("You Must Enter a vaild Email!");
            }
        }
    }
}
