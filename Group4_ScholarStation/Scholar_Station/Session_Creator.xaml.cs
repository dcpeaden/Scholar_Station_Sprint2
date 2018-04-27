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
    public partial class Session_Creator : Window
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
        private User user;
        private LandingPage lp;

        public Session_Creator(User user, LandingPage p)
        {
            lp = p;
            sqlHandler = new SQLHandlerControler();
            this.user = user;
            InitializeComponent();
            AddDepartmentsToComboBox();
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
                lp.tutorSessionsSelect.Items.Clear();
                lp.tutorSessionsSelect.Items.Add("--Select Session--");
                lp.tutorSessionsSelect.SelectedIndex = 0;
                lp.AddSessionsToComboBox();
            }
            else MessageBox.Show("You must select course, tutor, and session!");
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

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}