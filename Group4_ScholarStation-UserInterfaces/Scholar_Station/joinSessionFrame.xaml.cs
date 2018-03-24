using DataAccessControler;
using ScholarStation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;


namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class joinSessionFrame : Page
    {
        private List<string> tutorList;
        private List<string> classList;
        private List<string> departmentList;
        private List<string> sessionIdList;
        private User user;
        private IRead readFromDatabase;
        private IConnection closeDbConnection;
        private IUpdate updateDatabase;

        public joinSessionFrame(User newStudentUser)
        {
            this.user = newStudentUser;
            InitializeComponent();
            addDepartmentsToComboBox();
            viewurrentEnrolledSessions();
        }

        /* Add departments to comboBox
         * Connect to database and create a paramaterized sql query 
         * to retreve content from database to show in comboBox*/

        public void addDepartmentsToComboBox()
        {

            readFromDatabase = new ConnectionControler();

            //Clear all lower comboxBoxes.
            classesBox.Items.Clear();
            departmentList = new List<string>();
            string myCommand = "select * from department";
            SqlDataReader departmentList_dr = readFromDatabase.DataReader(myCommand);

            while (departmentList_dr.Read())
            {
                departmentList.Add(departmentList_dr.GetValue(0).ToString());
                departmentBox.Items.Add(departmentList_dr.GetValue(0).ToString() + " " + departmentList_dr.GetValue(1).ToString());
            }

            closeDbConnection = new ConnectionControler();
            closeDbConnection.closeConnection();
        }

        /*Add all courses to comboBox of selected department
         * Connect to database and create a paramaterized sql query 
         * to retreve content from database to show in comboBox*/
        public void addCoursesToComboBox()
        {
            readFromDatabase = new ConnectionControler();

            //Clear all lower comboxBoxes and their associated list.
            classesBox.Items.Clear();
            SessionTimeBox.Items.Clear();
            tutorBox.Items.Clear();
            classList = new List<string>();

            string myCommand = "select * from course where cr_dept_id = '" + departmentList[departmentBox.SelectedIndex].ToString() + "'";
            SqlDataReader courseList_dr = readFromDatabase.DataReader(myCommand);

            while (courseList_dr.Read())
            {
                classList.Add(courseList_dr.GetValue(0).ToString());
                classesBox.Items.Add(courseList_dr.GetValue(0).ToString() + " " + courseList_dr.GetValue(1).ToString());
            }

            closeDbConnection = new ConnectionControler();
            closeDbConnection.closeConnection();
        }

        /* Add all tutors from selected class into comboBox
         * Connect to database and create a paramaterized sql query
         * to retreve content from database to show in comboBox*/
        public void addTutorsToComboBox()
        {
            readFromDatabase = new ConnectionControler();

            tutorBox.Items.Clear();
            tutorList = new List<string>();
            if (classList != null && classesBox.SelectedIndex != -1)
            {
                string myCommand = "select * from tutors where tutor_cr_num = '" + classList[classesBox.SelectedIndex].ToString() + "'";
                SqlDataReader avalList_dr = readFromDatabase.DataReader(myCommand);

                while (avalList_dr.Read())
                {
                    tutorList.Add(avalList_dr.GetValue(0).ToString());
                    tutorBox.Items.Add(avalList_dr.GetValue(0).ToString());
                }
            }

            closeDbConnection = new ConnectionControler();
            closeDbConnection.closeConnection();
        }

        /* Add tutor avalibility and then create a connection
         * to the database and create a paramaterized sql query 
         * to retreve content from database to show in comboBox*/
        public void addTutorsAval()
        {
            readFromDatabase = new ConnectionControler();

            SessionTimeBox.Items.Clear();
            sessionIdList = new List<string>();
            if (tutorList != null && tutorBox.SelectedIndex != -1)
            {
                String myCommand = "select * from t_session where ses_tutor_email = '" + tutorList[tutorBox.SelectedIndex].ToString() + "'";
                SqlDataReader avalList_dr = readFromDatabase.DataReader(myCommand);

                while (avalList_dr.Read())
                {
                    //Take a substring of date for proper formatting
                    string dateStringTrim = avalList_dr.GetValue(2).ToString();
                    sessionIdList.Add(avalList_dr.GetValue(8).ToString());
                    SessionTimeBox.Items.Add("Date: " + dateStringTrim.Substring(0, dateStringTrim.Length - 11) + " Time: " + avalList_dr.GetValue(3).ToString());
                }
            }

            closeDbConnection = new ConnectionControler();
            closeDbConnection.closeConnection();
        }

        //Join the session
        public void joinTutorSession()
        {
            updateDatabase = new ConnectionControler();

            if (SessionTimeBox.SelectedIndex != -1)
            {
                    string myCommand = "UPDATE t_session  SET ses_student_email = '" + user.Email + "' Where sessionID = " + sessionIdList[SessionTimeBox.SelectedIndex].ToString();
                    updateDatabase.ExecuteQueries(myCommand);
                    MessageBox.Show("Session Joined!");
            }
            else MessageBox.Show("You must select course, tutor, and session!");
            //Update textbox to display currenct enrolled sessions
            viewurrentEnrolledSessions();
        }

        public void viewurrentEnrolledSessions()
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
        private void departmentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addCoursesToComboBox();
        }

        //Get state change from the classes comboBox to load the tutor box
        private void classesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addTutorsToComboBox();
        }

        //Get state change from the tutors comboBox to load the sessions box
        private void tutorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addTutorsAval();
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new logInFrame());
        }

        private void joinSession_Click_1(object sender, RoutedEventArgs e)
        {
            joinTutorSession();
        }
    }
}