﻿using ScholarStation;
using SQLHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Page
    {
        private User user;
        private ISQLHandler sqlHandler;
        private IList<string> tutorSessionIDs;
        private IList<string> studentSessionIDs;
        private int selectedTutorSession;
        private int selectedStudentSession;

        public LandingPage(User user)
        {
            this.user = user;
            sqlHandler = new SQLHandlerControler();
            InitializeComponent();
            welcome.Content = "Welcome, " + user.Email + "!";
            populateSessionsComboBox();
            populateStudentSessionsComboBox();
            
            
        }

        private void createSession_Click(object sender, RoutedEventArgs e)
        {

            //These two lines are here only to view the other canvas so I can work.
            //This code will be executed after there is a user type check to choose 
            //which canvas to show.
            professor.Visibility = Visibility.Visible;
            stdUser.Visibility = Visibility.Hidden;

            //this.NavigationService.Navigate(new tutorPage(user));
        }

        private void joinSession_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new joinSessionFrame(user));
        }

        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new logInFrame());
        }

        private void populateSessionsComboBox()
        {
            tutorSessionsSelect.Items.Add("--Select Session--");
            tutorSessionsSelect.SelectedIndex = 0;
            
            AddSessionsToComboBox();
        }

        public void AddSessionsToComboBox()
        {
            IDataReader sessions = sqlHandler.ViewCurrentSession(user.Email);
            tutorSessionIDs = new List<string>();
            tutorSessionIDs.Add("null");
            while (sessions.Read())
            {
                tutorSessionIDs.Add(sessions.GetValue(8).ToString());
                tutorSessionsSelect.Items.Add("Ses. ID: " + sessions.GetValue(8).ToString().PadLeft(4, '0') + "   " + getDate(sessions, 2)
                                              + " " + sessions.GetValue(3).ToString()); 
            }
        }

        private void populateStudentSessionsComboBox()
        {
            studentSessionsSelect.Items.Add("--Select Session--");
            studentSessionsSelect.SelectedIndex = 0;
            
            AddStudentSessionsToComboBox();
        }

        public void AddStudentSessionsToComboBox()
        {
            IDataReader sessions = sqlHandler.ViewCurrentSessionStudent(user.Email);
            studentSessionIDs = new List<string>();
            studentSessionIDs.Add("null");
            while (sessions.Read())
            {
                studentSessionIDs.Add(sessions.GetValue(8).ToString());
                studentSessionsSelect.Items.Add("Ses. ID: " + sessions.GetValue(8).ToString().PadLeft(4, '0') + "   " 
                                                 + getDate(sessions, 2) + " " + sessions.GetValue(3).ToString());
            }
        }

        private String getDate(IDataReader reader, int column)
        {
            String[] temp;
            
            temp = reader.GetValue(column).ToString().Split(' ');
            
            return temp[0];
        }

        private void tutorSessionsSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTutorSession = tutorSessionsSelect.SelectedIndex;

            if (selectedTutorSession == 0)  tutorSessionDetails.IsEnabled = false;
            else tutorSessionDetails.IsEnabled = true;
        }

        private void studentSessionsSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedStudentSession = studentSessionsSelect.SelectedIndex;

            if (selectedStudentSession == 0) studentSessionDetails.IsEnabled = false;
            else studentSessionDetails.IsEnabled = true;
        }

        private void tutorSessionDetails_Click(object sender, RoutedEventArgs e)
        {
            sessionDetails.Visibility = Visibility.Visible;
            professor.Visibility = Visibility.Hidden;
            stdUser.Visibility = Visibility.Hidden;
            string str = "";
            IDataReader sessions = sqlHandler.ViewCurrentSessionByID(tutorSessionIDs[selectedTutorSession].ToString());
            while (sessions.Read())
            {
                 str += "Session ID:  " + tutorSessionIDs[selectedTutorSession].ToString() + "\n"
                                  + "Date:  " + sessions.GetValue(2).ToString() + "\n"
                                  + "Start Time:  " + sessions.GetValue(3).ToString() + "\n"
                                  + "Duration:  " + sessions.GetValue(4).ToString() + " minutes\n"
                                  + "Course of interest:  " + sessions.GetValue(7).ToString() + "\n";
            }
            details.Content = str;
        }

        private void studentSessionDetails_Click(object sender, RoutedEventArgs e)
        {
            sessionDetails.Visibility = Visibility.Visible;
            professor.Visibility = Visibility.Hidden;
            stdUser.Visibility = Visibility.Hidden;
            details.Content = "Session ID:  " + studentSessionIDs[selectedStudentSession].ToString();
        }

        private void cancelSession_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void closeSession_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
