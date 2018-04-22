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
        private ISQLHandler sqlHandler;
        private IUserFactory user;

        public UserCreationWizard()
        {
            InitializeComponent();
            this.sqlHandler = new SQLHandlerControler();
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
            if (Regex.IsMatch(emailBox.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                if (passwordBox1.Password == passwordBox2.Password)
                {
                    if (String.IsNullOrEmpty(firstNameBox.Text) && String.IsNullOrEmpty(lastNameBox.Text) && String.IsNullOrEmpty(emailBox.Text))
                    {
                        MessageBox.Show("Please fill out enter form!");
                    }
                    else if (passwordBox1.Password.Length >= 7)
                    {
                        MessageBox.Show(sqlHandler.CreateAccout(firstNameBox.Text, lastNameBox.Text, emailBox.Text, passwordBox1.Password));
                        this.NavigationService.Navigate(new logInFrame());
                    }
                    else
                    {
                        MessageBox.Show("Password must be at least seven characters!");
                        passwordBox1.Clear();
                        passwordBox2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Your passwords do not match!");
                    passwordBox1.Clear();
                    passwordBox2.Clear();
                }
            }
            else
            {
                MessageBox.Show("Invalid Email!");
                emailBox.Clear();
            }
            
        }

        private void cancleButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new logInFrame());
        }
    }
}
