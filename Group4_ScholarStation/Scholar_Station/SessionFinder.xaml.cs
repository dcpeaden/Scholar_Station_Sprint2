using EmailControler;
using ScholarStation;
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
using System.Windows.Shapes;

namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for SessionFinder.xaml
    /// </summary>
    public partial class SessionFinder2 : Window
    {
        private IList<string> tutor;
        private IList<string> sessionIdList;
        private User user;
        private IList<string> departments;
        private IList<string> classes;
        private ISQLHandler sqlHandler;
        private LandingPage lp;


        public SessionFinder2(User newStudentUser, LandingPage p)
        {
            lp = p;
            sqlHandler = new SQLHandlerControler();
            this.user = newStudentUser;
            InitializeComponent();
            AddDepartmentsToComboBox();
        }

        public SessionFinder2(User newStudentUser)
        {
            sqlHandler = new SQLHandlerControler();
            this.user = newStudentUser;
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
                courseBox.Items.Add(classList.GetValue(0).ToString() + " " + classList.GetValue(1).ToString());
            }
        }

        /* Add all tutors from selected class into comboBox
         * Connect to database and create a paramaterized sql query
         * to retreve content from database to show in comboBox*/
        public void addTutorsToComboBox()
        {
            tutor = new List<string>();
            if (tutor != null && courseBox.SelectedIndex != -1)
            {
                IDataReader tutorList = sqlHandler.GetTutor(classes[courseBox.SelectedIndex].ToString());
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
                    sessionLengthBox.Items.Add(sessiont_dr.GetValue(2).ToString() + " " + sessiont_dr.GetValue(3).ToString());
                }
            }
        }

        //Join the session
        public void JoinTutorSession()
        {
            if (user == null)
            {
                MessageBox.Show("You must login before joining a session");
            }
            else if (sessionLengthBox.SelectedIndex != -1)
            {
                sqlHandler.JoinSession(user.Email, sessionIdList[sessionLengthBox.SelectedIndex].ToString());
                MessageBox.Show("Session Joined!");
                lp.studentSessionsSelect.Items.Clear();
                lp.studentSessionsSelect.Items.Add("--Select Session--");
                lp.studentSessionsSelect.SelectedIndex = 0;
                lp.AddStudentSessionsToComboBox();
                SendEmail();
            }
            else MessageBox.Show("You must select course, tutor, and session!");
        }

        public void SendEmail()
        {
            IMailHandler sendEmail = new MailHandler();
            sendEmail.JoinSession(tutor[tutorBox.SelectedIndex].ToString(), sessionIdList[sessionLengthBox.SelectedIndex].ToString());
            sendEmail.JoinSession(user.Email, sessionIdList[sessionLengthBox.SelectedIndex].ToString());
            MessageBox.Show("Email notification sent!");
        }

        private void departmentBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            courseBox.Items.Clear();
            sessionLengthBox.Items.Clear();
            tutorBox.Items.Clear();
            AddCoursesToComboBox();
        }

        private void courseBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            sessionLengthBox.Items.Clear();
            tutorBox.Items.Clear();
            addTutorsToComboBox();
        }

        private void tutorBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            addTutorsAval();
        }

        private void joinSession_Click(object sender, RoutedEventArgs e)
        {
            JoinTutorSession();
        }

        private void cancleSession_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
