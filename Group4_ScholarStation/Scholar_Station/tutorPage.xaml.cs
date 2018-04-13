using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataAccessControler;
using System.Data.SqlClient;
using ScholarStation;
using System.Data;
using SQLHandler;
using SQLHandler.Interfaces;

namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for tutorPage.xaml
    /// </summary>
    public partial class tutorPage : Page
    {
        private IList<string> sessionLengthList;
        private IList<string> addDate;
        private IList<string> addTime;
        private ISessionLength sessionLength;
        private ISQLHandler sqlHandler;
        private IDate date;
        private ITime time;
        private IList<string> departments;
        private IList<string> classes;
        private IList<string> sessionIdList;
        private User user;

        public tutorPage(User user)
        {
            sqlHandler = new SQLHandlerControler();
            this.user = user;
            InitializeComponent();
            AddDepartmentsToComboBox();
            SessionIds();
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

        public void FillDateBox()
        {
            date = new Date();
            addDate = date.FillDate();
            foreach (var date in addDate)
            { 
                dateBox.Items.Add(date);
            }
        }

        //Fill the time box with dates of the currentmonth
        public void FillTimeBox()
        {
            time = new Time();
            addTime = time.getTime();
            foreach (var t in addTime)
            {
                timeBox.Items.Add(t);
            }
        }

        //Fill session length box with 15 min increments
        public void FillSessionLengthBox()
        {
            sessionLength = new SessionLength();
            sessionLengthList = sessionLength.AddSessionLength();
            foreach (var t in sessionLengthList)
            {
                sessionLengthBox.Items.Add(t);
            }
        }

        //Fill cancled session comboBox with avaliable sessions from the database
        public void SessionIds()
        {
            sessionIdBox.Items.Clear();
            sessionIdList = sqlHandler.getSessionsID(user.Email);
            foreach (var t in sessionIdList)
            {
                sessionIdBox.Items.Add(t);
            }
        }

        public void CancelSession()
        {
            if (sessionIdBox.SelectedIndex != -1)
            {
                sqlHandler.CancelSessions(sessionIdList[sessionIdBox.SelectedIndex]);
                MessageBox.Show("Session Canceled");
                sessionIdBox.Items.RemoveAt(sessionIdBox.SelectedIndex);
            }
            else
            {
                MessageBox.Show("You Must Select A Session Id!");
            }
        }

        //Add sessions to database
        public void AddToSessionsAndTutors()
        {
            string date = addDate[dateBox.SelectedIndex];
            string time = addTime[timeBox.SelectedIndex];
            string length = sessionLengthList[sessionLengthBox.SelectedIndex];
            string sellectedClass = classes[classesBox.SelectedIndex];

            if (sessionLengthBox.SelectedIndex != -1)
            {
               sqlHandler.CreateSession(user.Email, date, time, length, sellectedClass);
               MessageBox.Show("Session Created!");
            }
            else MessageBox.Show("You must select course, tutor, and session!");

            //Clear and refresh the session idBox to refill with new session id
            sessionIdBox.Items.Clear();
            SessionIds();
        }
        
        public void ViewTutorsCurrentSessions()
        {
            textBox.Clear();
            IDataReader currentSessionList = sqlHandler.ViewCurrentSession(user.Email);
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
            
        }

        
        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new logInFrame());
        }

        private void departmentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Clear all lower comboxBoxes and their associated list.
            classesBox.Items.Clear();
            dateBox.Items.Clear();
            timeBox.Items.Clear();
            sessionLengthBox.Items.Clear();
            AddCoursesToComboBox();
        }

        private void classesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dateBox.Items.Clear();
            timeBox.Items.Clear();
            sessionLengthBox.Items.Clear();
            FillDateBox();
        }

        private void dateBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            timeBox.Items.Clear();
            sessionLengthBox.Items.Clear();
            FillTimeBox();
        }

        private void timeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sessionLengthBox.Items.Clear();
            FillSessionLengthBox();
        }

        private void createSessionButton_Click(object sender, RoutedEventArgs e)
        {
            AddToSessionsAndTutors();
            classesBox.Items.Clear();
            dateBox.Items.Clear();
            timeBox.Items.Clear();
            sessionLengthBox.Items.Clear();
        }

        private void viewSessionsButton_Click(object sender, RoutedEventArgs e)
        {
            ViewTutorsCurrentSessions();
        }

        private void cancelSessionButton_Click(object sender, RoutedEventArgs e)
        {
            CancelSession();
        }

    }
}