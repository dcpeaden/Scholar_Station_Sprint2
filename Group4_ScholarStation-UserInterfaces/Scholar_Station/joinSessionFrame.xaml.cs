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
        private static IConnection dbConnection;
        private List<string> tutorList;
        private List<string> classList;
        private List<string> departmentList;
        private List<string> sessionIdList;
        private User user;

        public joinSessionFrame(User newStudentUser)
        {
            this.user = newStudentUser;
            InitializeComponent();
            addDepartmentsToComboBox();
        }

        //Create a connection to the database by creating a connection object
        public void connectToDatabase()
        {
            dbConnection = new ConnectionControler();
            dbConnection.openConnection();
        }

        /* Add departments to comboBox
         * Connect to database and create a paramaterized sql query 
         * to retreve content from database to show in comboBox*/

        public void addDepartmentsToComboBox()
        {
            connectToDatabase();

            //Clear all lower comboxBoxes.
            classesBox.Items.Clear();
            departmentList = new List<string>();
            string myCommand = "select * from department";
            SqlDataReader departmentList_dr = dbConnection.DataReader(myCommand);

            while (departmentList_dr.Read())
            {
                departmentList.Add(departmentList_dr.GetValue(0).ToString());
                departmentBox.Items.Add(departmentList_dr.GetValue(0).ToString() + " " + departmentList_dr.GetValue(1).ToString());
            }

            dbConnection.closeConnection();
        }

        /*Add all courses to comboBox of selected department
         * Connect to database and create a paramaterized sql query 
         * to retreve content from database to show in comboBox*/
        public void addCoursesToComboBox()
        {
            connectToDatabase();

            //Clear all lower comboxBoxes and their associated list.
            classesBox.Items.Clear();
            SessionTimeBox.Items.Clear();
            tutorBox.Items.Clear();
            classList = new List<string>();

            string myCommand = "select * from course where cr_dept_id = '" + departmentList[departmentBox.SelectedIndex].ToString() + "'";
            SqlDataReader courseList_dr = dbConnection.DataReader(myCommand);

            while (courseList_dr.Read())
            {
                classList.Add(courseList_dr.GetValue(0).ToString());
                classesBox.Items.Add(courseList_dr.GetValue(0).ToString() + " " + courseList_dr.GetValue(1).ToString());
            }

            dbConnection.closeConnection();
        }

        /* Add all tutors from selected class into comboBox
         * Connect to database and create a paramaterized sql query
         * to retreve content from database to show in comboBox*/
        public void addTutorsToComboBox()
        {
            connectToDatabase();
            tutorBox.Items.Clear();
            tutorList = new List<string>();
            if (classList != null && classesBox.SelectedIndex != -1)
            {
                string myCommand = "select * from tutors where tutor_cr_num = '" + classList[classesBox.SelectedIndex].ToString() + "'";
                SqlDataReader avalList_dr = dbConnection.DataReader(myCommand);

                while (avalList_dr.Read())
                {
                    tutorList.Add(avalList_dr.GetValue(0).ToString());
                    tutorBox.Items.Add(avalList_dr.GetValue(0).ToString());
                }
            }
            dbConnection.closeConnection();
        }

        /* Add tutor avalibility and then create a connection
         * to the database and create a paramaterized sql query 
         * to retreve content from database to show in comboBox*/
        public void addTutorsAval()
        {
            connectToDatabase();
            SessionTimeBox.Items.Clear();
            sessionIdList = new List<string>();
            if (tutorList != null && tutorBox.SelectedIndex != -1)
            {
                String myCommand = "select * from t_session where ses_tutor_email = '" + tutorList[tutorBox.SelectedIndex].ToString() + "'";
                SqlDataReader avalList_dr = dbConnection.DataReader(myCommand);

                while (avalList_dr.Read())
                {
                    sessionIdList.Add(avalList_dr.GetValue(8).ToString());
                    SessionTimeBox.Items.Add(avalList_dr.GetValue(2).ToString());
                }
            }
            dbConnection.closeConnection();
        }

        //Join the session
        public void joinTutorSession()
        {
            if (SessionTimeBox.SelectedIndex != -1)
            {
                    string myCommand = "UPDATE t_session  SET ses_student_email = '" + user.Email + "' Where sessionID = " + sessionIdList[SessionTimeBox.SelectedIndex].ToString();
                    dbConnection.ExecuteQueries(myCommand);
                    MessageBox.Show("Session Joined!");
            }
            else MessageBox.Show("You must select course, tutor, and session!");
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