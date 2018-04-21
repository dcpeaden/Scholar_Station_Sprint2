using System.Windows;
using System.Windows.Controls;
using ScholarStation;
using System.Text.RegularExpressions;
using SQLHandler;
using System.Data;
using System;

namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for logInFrame.xaml
    /// </summary>
    public partial class logInFrame : Page
    {
        private IUserFactory user;
        private ISQLHandler sqlHandler;

        public logInFrame()
        {
            InitializeComponent();
            sqlHandler = new SQLHandlerControler();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            inputValidationCheck();
        }

        private UserType getUserType(string email, string password)
        {
            int thisType = 0;
            string type = "";

            IDataReader userType = sqlHandler.GetUserType(email, password);

            while (userType.Read())
            {
                type = userType.GetValue(0).ToString();
                thisType = Int32.Parse(type);
            }
            
            if (thisType == 0) return UserType.Administrator;
            else if(thisType == 1) return UserType.Standard;
            if (thisType == 2) return UserType.Professor;
           
            return UserType.Null;
        }

        public void inputValidationCheck()
        {
            if (Regex.IsMatch(emailBox.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
           {
                user = new UserFactory();
                User newUser = user.CreateUser("name", 1, getUserType(emailBox.Text, passwordBox.Text), emailBox.Text);

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
