using ScholarStation;
using SQLHandler;
using SQLHandler.Interfaces;
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
        private string currentID;
        private IList<string> tutorSessionIDs;
        private IList<string> studentSessionIDs;
        private IList<string> professorCourses;
        private IList<string> feedbackSessionIDs;

        public LandingPage(User user)
        {
            this.user = user;
            sqlHandler = new SQLHandlerControler();
            InitializeComponent();
            welcome.Content = "Welcome, " + user.Email + "!";
            populateSessionsComboBox();
            populateStudentSessionsComboBox();
            populateProfessorCoursesComboBox();
            
            routeView(user.Type);

        }

        private void routeView(UserType type)
        {
            if(type == UserType.Standard)
            {
                professor.Visibility = Visibility.Hidden;
                stdUser.Visibility = Visibility.Visible;
                contactAdmin.Visibility = Visibility.Hidden;
            }
            else if(type == UserType.Professor)
            {
                professor.Visibility = Visibility.Visible;
                stdUser.Visibility = Visibility.Hidden;
                contactAdmin.Visibility = Visibility.Hidden;
            }
            else
            {
                professor.Visibility = Visibility.Hidden;
                stdUser.Visibility = Visibility.Hidden;
                contactAdmin.Visibility = Visibility.Visible;
                welcomeBanner.Visibility = Visibility.Hidden;
                contactAdminLabel.Content = user.Email + " does not exist in system.\n" 
                                            + "To use Scholar Station, please contact admin.";
            }
        }

        private void toLogin_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new logInFrame());
        }

        private void createSession_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new tutorPage(user));
        }

        private void joinSession_Click(object sender, RoutedEventArgs e)
        {
            SessionFinder.MainWindow sessionSearch = new SessionFinder.MainWindow(user);
            sessionSearch.Show();
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
            String[] temp = reader.GetValue(column).ToString().Split(' ');
            
            return temp[0];
        }

        private void tutorSessionsSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tutorSessionsSelect.SelectedIndex == 0)  tutorSessionDetails.IsEnabled = false;
            else tutorSessionDetails.IsEnabled = true;
        }

        private void studentSessionsSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (studentSessionsSelect.SelectedIndex == 0) studentSessionDetails.IsEnabled = false;
            else studentSessionDetails.IsEnabled = true;
        }

        private void tutorSessionDetails_Click(object sender, RoutedEventArgs e)
        {
            sessionDetails.Visibility = Visibility.Visible;
            professor.Visibility = Visibility.Hidden;
            stdUser.Visibility = Visibility.Hidden;

            string str = "";
            currentID = tutorSessionIDs[tutorSessionsSelect.SelectedIndex].ToString();

            IDataReader sessions = sqlHandler.ViewCurrentSessionByID(tutorSessionIDs[tutorSessionsSelect.SelectedIndex].ToString());
            while (sessions.Read())
            {
                 str += "Session ID:  " + tutorSessionIDs[tutorSessionsSelect.SelectedIndex].ToString() + "\n"
                                  + "Date:  " + getDate(sessions, 2) + "\n"
                                  + "Start Time:  " + sessions.GetValue(3).ToString() + "\n"
                                  + "Duration:  " + sessions.GetValue(4).ToString() + " minutes\n"
                                  + "Course of interest:  " + sessions.GetValue(7).ToString() + "\n"
                                  + "Tutor:  " + sessions.GetValue(0).ToString();
            }
            details.Content = str;
        }

        private void studentSessionDetails_Click(object sender, RoutedEventArgs e)
        {
            sessionDetails.Visibility = Visibility.Visible;
            professor.Visibility = Visibility.Hidden;
            stdUser.Visibility = Visibility.Hidden;

            string str = "";
            currentID = studentSessionIDs[studentSessionsSelect.SelectedIndex].ToString();

            IDataReader sessions = sqlHandler.ViewCurrentSessionByID(studentSessionIDs[studentSessionsSelect.SelectedIndex].ToString());

            while (sessions.Read())
            {
                str += "Session ID:  " + studentSessionIDs[studentSessionsSelect.SelectedIndex].ToString() + "\n"
                                 + "Date:  " + getDate(sessions, 2) + "\n"
                                 + "Start Time:  " + sessions.GetValue(3).ToString() + "\n"
                                 + "Duration:  " + sessions.GetValue(4).ToString() + " minutes\n"
                                 + "Course of interest:  " + sessions.GetValue(7).ToString() + "\n"
                                 + "Tutor:  " + sessions.GetValue(0).ToString();
            }
            details.Content = str;
        }

        private void cancelSession_Click(object sender, RoutedEventArgs e)
        {
            sqlHandler.CancelSessions(currentID);
            MessageBox.Show("Session Canceled");
        }

        private void closeSession_Click(object sender, RoutedEventArgs e)
        {
            Feedback_Form.MainWindow feedback = new Feedback_Form.MainWindow(user, currentID);
            feedback.Show();
        }

        private void populateProfessorCoursesComboBox()
        {
            professorCourseSelect.Items.Add("--Select Course--");
            professorCourseSelect.SelectedIndex = 0;

            AddProfessorCoursesToComboBox();
        }

        public void AddProfessorCoursesToComboBox()
        {
            IDataReader courses = sqlHandler.GetCourseByProfessor(user.Email);
            professorCourses = new List<string>();
            professorCourses.Add("null");
            while (courses.Read())
            {
                professorCourses.Add(courses.GetValue(0).ToString());
                professorCourseSelect.Items.Add(courses.GetValue(0).ToString() + "   " + courses.GetValue(1).ToString());
            }
        }

        private void professorCourseSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (professorCourseSelect.SelectedIndex == 0) professorCourseDetails.IsEnabled = false;
            else professorCourseDetails.IsEnabled = true;
        }

        private void professorCourseDetails_Click(object sender, RoutedEventArgs e)
        {
            populateSessionSelectComboBox();
            sessionsLabel.Content = "Tutoring sessions related to " + professorCourses[professorCourseSelect.SelectedIndex] + ":";
            sessionsLabel.Visibility = Visibility.Visible;
            sessionSelect.Visibility = Visibility.Visible;
            viewSessionFeedback.Visibility = Visibility.Visible;
        }

        private void sessionSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sessionSelect.SelectedIndex == 0) viewSessionFeedback.IsEnabled = false;
            else viewSessionFeedback.IsEnabled = true;
        }

        private void viewSessionFeedback_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void populateSessionSelectComboBox()
        {
            sessionSelect.Items.Add("--Select Session--");
            sessionSelect.SelectedIndex = 0;

            AddFeedbackSessionsToComboBox();
        }

        public void AddFeedbackSessionsToComboBox()
        {
            IDataReader sessions = sqlHandler.GetCompletedSessionsByCourse(professorCourses[professorCourseSelect.SelectedIndex].ToString()); ;
            feedbackSessionIDs = new List<string>();
            feedbackSessionIDs.Add("null");
            while (sessions.Read())
            {
                feedbackSessionIDs.Add(sessions.GetValue(8).ToString());
                sessionSelect.Items.Add(getDate(sessions, 2) + "   "
                                                    + sessions.GetValue(3).ToString());
            }
        }
    }
}
