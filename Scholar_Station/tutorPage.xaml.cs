using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataAccessControler;
using System.Data.SqlClient;
using ScholarStation;

namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for tutorPage.xaml
    /// </summary>
    public partial class tutorPage : Page
    {
        private IRead readFromDatabase;
        private IConnection closeDbConnection;
        private IUpdate updateDatabase;
        private List<string> departmentList;
        private List<string> classList;
        private List<string> sessionDateList;
        private List<string> sessionTimeList;
        private List<float> sessionLengthList;
        private List<string> sessionIdList;
        private User user;

        public tutorPage(User user)
        {
            this.user = user;
            InitializeComponent();
            addDepartmentsToComboBox();
            sessionIds();
        }

        /* Add departments to comboBox
         * Connect to database and create a paramaterized sql query 
         * to retreve content from database to show in comboBox*/

        public void addDepartmentsToComboBox()
        {
            readFromDatabase = new ConnectionControler();

            departmentList = new List<string>();

            //Clear all lower comboxBoxes.
            classesBox.Items.Clear();
            string myCommand = "select * from department";
            SqlDataReader departmentList_dr = readFromDatabase.DataReader(myCommand);

            while (departmentList_dr.Read())
            {
                departmentList.Add(departmentList_dr.GetValue(0).ToString());
                departmentBox.Items.Add(departmentList_dr.GetValue(0).ToString() + " " + departmentList_dr.GetValue(1).ToString());
            }

            //Close Connection
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
            dateBox.Items.Clear();
            timeBox.Items.Clear();
            sessionLengthBox.Items.Clear();
            classList = new List<string>();
            string myCommand = "select * from course where cr_dept_id = '" + departmentList[departmentBox.SelectedIndex].ToString() + "'";
            SqlDataReader courseList_dr = readFromDatabase.DataReader(myCommand);

            while (courseList_dr.Read())
            {
                classList.Add(courseList_dr.GetValue(0).ToString());
                classesBox.Items.Add(courseList_dr.GetValue(0).ToString() + " " + courseList_dr.GetValue(1).ToString());
            }

            //Close Connection
            closeDbConnection = new ConnectionControler();
            closeDbConnection.closeConnection();

        }

        public void fillDateBox()
        {
            //clear comboBoxes
            dateBox.Items.Clear();
            timeBox.Items.Clear();
            sessionLengthBox.Items.Clear();
            sessionDateList = new List<string>();
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int[] days = Enumerable.Range(1, DateTime.DaysInMonth(year, month)).ToArray();
            string date;
            for (int i = 0; i <= days.Length - 1; i++)
            {
                if(i >= day)
                {
                    date = month + "/" + days[i] + "/" + year;
                    sessionDateList.Add(date);
                    dateBox.Items.Add(date);
                }
               
            }
        }

        //Fill the time box with dates of the currentmonth
        public void fillTimeBox()
        {
            timeBox.Items.Clear();
            sessionLengthBox.Items.Clear();
            sessionTimeList = new List<string>();
            DateTime time = DateTime.Today;
            //from 8h to 22h hours
            for (DateTime _time = time.AddHours(08); _time < time.AddHours(22); _time = _time.AddMinutes(15)) //from 8h to 22h hours
            {
                sessionTimeList.Add(_time.ToShortTimeString());
                timeBox.Items.Add(_time.ToShortTimeString());
            }
        }

        //Fill session length box with 15 min increments
        public void fillSessionLengthBox()
        {
            readFromDatabase = new ConnectionControler();

            sessionLengthList = new List<float>();
            float lengthOfSession = 0;
            for (int i = 0; i <= 3; i++)
            {
                lengthOfSession += 15;
                sessionLengthList.Add(lengthOfSession);
                sessionLengthBox.Items.Add(lengthOfSession);
            }

            //Close Connection
            closeDbConnection = new ConnectionControler();
            closeDbConnection.closeConnection();

        }

        //Fill cancled session comboBox with avaliable sessions from the database
        public void sessionIds()
        {
            readFromDatabase = new ConnectionControler();

            sessionIdList = new List<string>();
            String myCommand = "select * from t_session where ses_tutor_email = '" + user.Email + "'";
            SqlDataReader currentSessionList = readFromDatabase.DataReader(myCommand);

            while (currentSessionList.Read())
            {
                sessionIdList.Add(currentSessionList.GetValue(8).ToString());
                sessionIdBox.Items.Add(currentSessionList.GetValue(8).ToString());
            }

            //Close Connection
            closeDbConnection = new ConnectionControler();
            closeDbConnection.closeConnection();

        }

        public void cancelSession()
        {
            updateDatabase = new ConnectionControler();

            if (sessionIdBox.SelectedIndex != -1)
            {   
                String deleteSessionFromSessionTable = "Delete From t_session where sessionId = '" + sessionIdList[sessionIdBox.SelectedIndex].ToString() + "'";
                updateDatabase.ExecuteQueries(deleteSessionFromSessionTable);

                String deleteSessionFromTutorTable = "Delete From tutors where fk_sessionId = '" + sessionIdList[sessionIdBox.SelectedIndex].ToString() + "'";
                updateDatabase.ExecuteQueries(deleteSessionFromSessionTable);
                updateDatabase.ExecuteQueries(deleteSessionFromTutorTable);

                MessageBox.Show("Session Cancled");
                sessionIdBox.Items.RemoveAt(sessionIdBox.SelectedIndex);

            }
            else
            {
                MessageBox.Show("You Must Select A Session Id!");
            }
        }

        //Add sessions to database
        public void addToSessionsAndTutors()
        {
            
            updateDatabase = new ConnectionControler();

            if (sessionLengthBox.SelectedIndex != -1)
            {
                Random ran = new Random();
                int numberOfAllowedSessions = 10000;
                int sessID = isSessionIDUnique(ran.Next(numberOfAllowedSessions));

                string insertIntoSessions = "INSERT into t_session (ses_tutor_email , ses_student_email, ses_date, ses_start_time, ses_duration, ses_creator, ses_complete, ses_course, sessionId ) " +
                                   "VALUES ('" + user.Email
                                    + "', '" + null
                                    + "', '" + sessionDateList[dateBox.SelectedIndex].ToString()
                                    + "', '" + sessionTimeList[timeBox.SelectedIndex].ToString()
                                    + "', '" + sessionLengthList[sessionLengthBox.SelectedIndex].ToString()
                                    + "', '" + user.Email
                                    + "', '" + 0
                                    + "', '" + classList[classesBox.SelectedIndex].ToString()
                                    + "', '" + sessID + "')";

                updateDatabase.ExecuteQueries(insertIntoSessions);

                string insertIntotutors = "INSERT into tutors (tutor_email , tutor_cr_num, tutor_is_endorsed, fk_sessionID ) " +
                                   "VALUES ('" + user.Email
                                    + "', '" + classList[classesBox.SelectedIndex].ToString()
                                    + "', '" + 0 
                                    + "', '" + sessID + "')";

                updateDatabase.ExecuteQueries(insertIntotutors);
                
                MessageBox.Show("Session Created!");
            }
            else MessageBox.Show("You must select course, tutor, and session!");

            //Clear and refresh the session idBox to refill with new session id
            sessionIdBox.Items.Clear();
            sessionIds();

        }


        public void viewTutorsCurrentSessions()
        {
            readFromDatabase = new ConnectionControler();

            textBox.Clear();
            String myCommand = "select * from t_session where ses_tutor_email = '" + user.Email + "'";
            SqlDataReader currentSessionList = readFromDatabase.DataReader(myCommand);
            while (currentSessionList.Read())
            {
                    textBox.Text += "Session ID: " + currentSessionList.GetValue(8).ToString() + "\n"
                                              + "Date: " + currentSessionList.GetValue(2).ToString() + "\n"
                                              + "Time: " + currentSessionList.GetValue(3).ToString() + "\n"
                                              + "Length: " + currentSessionList.GetValue(4).ToString() + "\n"
                                              + "Creator: " + currentSessionList.GetValue(5).ToString() + "\n"
                                              + "Complete: " + currentSessionList.GetValue(6).ToString() + "\n"
                                              + "Course: " + currentSessionList.GetValue(7).ToString() + "\n"
                                              + "Student Email: " + currentSessionList.GetValue(1).ToString() + "\n"
                                              + "\n";
            }

            //Close Connection
            closeDbConnection = new ConnectionControler();
            closeDbConnection.closeConnection();

        }

        public int isSessionIDUnique(int newIdNumber)
        {
            readFromDatabase = new ConnectionControler();

            String myCommand = "select sessionId from t_session";
            SqlDataReader sessionIdList = readFromDatabase.DataReader(myCommand);
            while (sessionIdList.Read())
            {
                if ((int)sessionIdList.GetValue(0) == newIdNumber)
                {
                    newIdNumber = isSessionIDUnique(new Random().Next(newIdNumber));
                  
                }
            }
            MessageBox.Show("Session ID: " + newIdNumber.ToString());

            //Close Connection
            closeDbConnection = new ConnectionControler();
            closeDbConnection.closeConnection();

            return newIdNumber;
        }

        
        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new logInFrame());
        }

        private void departmentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addCoursesToComboBox();
        }

        private void classesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDateBox();
        }

        private void dateBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillTimeBox();
        }

        private void timeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillSessionLengthBox();
        }

        private void createSessionButton_Click(object sender, RoutedEventArgs e)
        {
            addToSessionsAndTutors();
        }

        private void viewSessionsButton_Click(object sender, RoutedEventArgs e)
        {
            viewTutorsCurrentSessions();
        }

        private void cancelSessionButton_Click(object sender, RoutedEventArgs e)
        {
            cancelSession();
        }

    }
}