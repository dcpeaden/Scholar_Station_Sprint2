using ScholarStation;
using SQLHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for UserCreationWizard.xaml
    /// </summary>
    public partial class UserCreationWizard : Page
    {
        
        private IUserFactory user;
        private ILoginInVarification loginInVarification;

        public UserCreationWizard()
        {
            InitializeComponent();
            this.loginInVarification = new LogInVarification();
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            user = new UserFactory();
            string name = firstNameBox.Text + " " + lastNameBox.Text;
            string id = passwordBox1.Password;
            int userType = 1;
            string userEmail = emailBox.Text;

            user = new UserFactory();
            User newUser = user.CreateUser(name, userType, UserType.Standard, emailBox.Text);

            if (!loginInVarification.IsFormFilledOut(firstNameBox.Text, lastNameBox.Text, emailBox.Text))
            {
                MessageBox.Show("Please fill out enter form!");
            }
            else if (!loginInVarification.CheckToSeeIfValidEmailFormat(emailBox.Text))
            {
                MessageBox.Show("Invalid Email!");
                emailBox.Clear();
                
            }
            else if (!loginInVarification.CheckToSeeIfPasswordIsCorrectLength(passwordBox1.Password.Length))
            {
                MessageBox.Show("Password must be at least seven characters!");
                passwordBox1.Clear();
                passwordBox2.Clear();
            }
            else if (!loginInVarification.CheckToSeeIfPasswordsAreSame(passwordBox1.Password, passwordBox2.Password))
            {
                MessageBox.Show("Your passwords do not match!");
                passwordBox1.Clear();
                passwordBox2.Clear();
            }
            else if (loginInVarification.CreateAccount(firstNameBox.Text, lastNameBox.Text, emailBox.Text, passwordBox1.Password))
            {
                MessageBox.Show("Email alread used!");
                firstNameBox.Clear();
                lastNameBox.Clear();
                emailBox.Clear();
                passwordBox1.Clear();
                passwordBox2.Clear();
            }
            else
            {
                this.NavigationService.Navigate(new LandingPage(newUser));
            }
        }
        private void cancleButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new logInFrame());
        }
    }
}
