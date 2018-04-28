using ScholarStation;
using SQLHandler;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for CreationWizardPage5.xaml
    /// </summary>
    public partial class CreationWizardPage5 : Page
    {
        private IList<string> addTime;
        private IList<string> addDate;
        private IList<string> sessionLengthList;
        private IList<string> departments;
        private IList<string> classes;
        private ISQLHandler sqlHandler;
        private ISessionLength sessionLength;
        private ITime time;
        private User user;
        private LandingPage lp;
        private string date;
        private string selectedClass;

        public CreationWizardPage5(User user, LandingPage p, IList<string> departments, IList<string> classes, string selectedClass, IList<string> addDate, string date)
        {
            lp = p;
            this.user = user;
            this.departments = departments;
            this.classes = classes;
            this.addDate = addDate;
            this.date = date;
            this.selectedClass = selectedClass;
            sqlHandler = new SQLHandlerControler();
            InitializeComponent();
            FillSessionLengthBox();
            FillTimeBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreationWizardPage4(user, lp, departments, classes, selectedClass));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreationWizardWindow window = new CreationWizardWindow();
            window.Hide();
            this.NavigationService.Navigate(window);
            window.Close();
        }

        public void FillTimeBox()
        {
            time = new Time();
            addTime = time.getTime();
            foreach (var t in addTime)
            {
                combo.Items.Add(t);
            }
        }

        public void FillSessionLengthBox()
        {
            sessionLength = new SessionLength();
            sessionLengthList = sessionLength.AddSessionLength();

            foreach (var t in sessionLengthList)
            {
                combo2.Items.Add(t);
            }
        }

        public void AddToSessionsAndTutors()
        {
            int dateInt = Convert.ToInt32(this.date);
            string date = addDate[dateInt];

            int classInt = Convert.ToInt32(this.selectedClass);
            string time = addTime[combo.SelectedIndex];
            string length = sessionLengthList[combo2.SelectedIndex];
            string sellectedClass = classes[classInt];

            if (combo2.SelectedIndex != -1)
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
    }
}
