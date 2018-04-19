using DataAccessControler;
using ScholarStation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using SQLHandler;
using System.Data;

namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class joinSessionFrame : Page
    {
        private IList<string> tutor;
        private IList<string> sessionIdList;
        private User user;
        private IList<string> departments;
        private IList<string> classes;
        private IRead readFromDatabase;
        private IConnection closeDbConnection;
        private ISQLHandler sqlHandler;

        public joinSessionFrame(User newStudentUser)
        {
            sqlHandler = new SQLHandlerControler();
            this.user = newStudentUser;
            InitializeComponent();
            AddDepartmentsToComboBox();
            ViewCurrentEnrolledSessions();
        }

        /* Add departments to comboBox
         * Connect to database and create a paramaterized sql query 
         * to retreve content from database to show in comboBox*/

        public void AddDepartmentsToComboBox()
        {
            departments = new List<string>();
            IDataReader departmentList = sqlHandler.GetDepartment();
            while (departmentList.Read())
            {
                departments.Add(departmentList.GetValue(0).ToString());
                departmentBox.Items.Add(departmentList.GetValue(0).ToString() + " " + departmentList.GetValue(1).ToString());
            }
        }

        /*Add all courses to comboBox of selected department
         * Connect to database and create a paramaterized sql query 
         * to retreve content from database to show in comboBox*/
        public void AddCoursesToComboBox()
        {
            classes = new List<string>();
            IDataReader classList = sqlHandler.GetCourse(departments[departmentBox.SelectedIndex].ToString());
            while (classList.Read())
            {
                classes.Add(classList.GetValue(0).ToString());
                classesBox.Items.Add(classList.GetValue(0).ToString() + " " + classList.GetValue(1).ToString());
            }
        }

        /* Add all tutors from selected class into comboBox
         * Connect to database and create a paramaterized sql query
         * to retreve content from database to show in comboBox*/
        public void addTutorsToComboBox()
        {
            tutor = new List<string>();
            if (tutor != null && classesBox.SelectedIndex != -1)
            {
                IDataReader tutorList = sqlHandler.GetTutor(classes[classesBox.SelectedIndex].ToString());
                while (tutorList.Read())
                {
                    tutor.Add(tutorList.GetValue(0).ToString());
                    tutorBox.Items.Add(tutorList.GetValue(0).ToString());
                }
            }
        }

        /* Add tutor avalibility and then create a connection
         * to the database and create a paramaterized sql query 
         * to retreve content from database to show in comboBox*/
        public void addTutorsAval()
        {
            sessionIdList = new List<string>();
            if (sessionIdList != null && tutorBox.SelectedIndex != -1)
            {
                IDataReader sessiont_dr = sqlHandler.GetAvailableSessions(tutor[tutorBox.SelectedIndex].ToString());
                while (sessiont_dr.Read())
                {
                    sessionIdList.Add(sessiont_dr.GetValue(8).ToString());
                    SessionTimeBox.Items.Add(sessiont_dr.GetValue(2).ToString() + " " + sessiont_dr.GetValue(3).ToString());
                }
            }
        }

        //Join the session
        public void JoinTutorSession()
        {
            if (SessionTimeBox.SelectedIndex != -1)
            {
                sqlHandler.JoinSession(user.Email, sessionIdList[SessionTimeBox.SelectedIndex].ToString());
                MessageBox.Show("Session Joined!");
            }
            else MessageBox.Show("You must select course, tutor, and session!");
            ViewCurrentEnrolledSessions();
        }

        public void ViewCurrentEnrolledSessions()
        {
            readFromDatabase = new ConnectionControler();

            textBox.Clear();
            String myCommand = "select * from t_session where ses_student_email = '" + user.Email + "'";
            SqlDataReader currentSessionList = readFromDatabase.DataReader(myCommand);
            while (currentSessionList.Read())
            {
                //Take a substring of date for proper formatting
                string dateStringTrim = currentSessionList.GetValue(2).ToString();
                textBox.Text += "Session ID: " + currentSessionList.GetValue(8).ToString() + "\n"
                                          + "Date: " + dateStringTrim.Substring(0, dateStringTrim.Length - 11) + "\n"
                                          + "Time: " + currentSessionList.GetValue(3).ToString() + "\n"
                                          + "Length: " + currentSessionList.GetValue(4).ToString() + "\n"
                                          + "Tutor: " + currentSessionList.GetValue(5).ToString() + "\n"
                                          + "Complete: " + currentSessionList.GetValue(6).ToString() + "\n"
                                          + "Course: " + currentSessionList.GetValue(7).ToString() + "\n"
                                          + "Student Email: " + currentSessionList.GetValue(1).ToString() + "\n"
                                          + "\n";
            }

            closeDbConnection = new ConnectionControler();
            closeDbConnection.closeConnection();
        }


        //Get state change from the department comboBox to load the course box
        private void DepartmentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            classesBox.Items.Clear();
            SessionTimeBox.Items.Clear();
            tutorBox.Items.Clear();
            AddCoursesToComboBox();
        }

        //Get state change from the classes comboBox to load the tutor box
        private void ClassesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SessionTimeBox.Items.Clear();
            tutorBox.Items.Clear();
            addTutorsToComboBox();
        }

        //Get state change from the tutors comboBox to load the sessions box
        private void TutorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addTutorsAval();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new logInFrame());
        }

        private void JoinSession_Click_1(object sender, RoutedEventArgs e)
        {
            JoinTutorSession();
        }
    }
}