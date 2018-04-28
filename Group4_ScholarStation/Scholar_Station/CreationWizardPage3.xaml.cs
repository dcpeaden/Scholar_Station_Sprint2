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
using System.Data;
using SQLHandler;
using ScholarStation;

namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for CreationWizardPage3.xaml
    /// </summary>
    public partial class CreationWizardPage3 : Page
    {
        private IList<string> classes;
        private IList<string> departments;
        private ISQLHandler sqlHandler;
        private User user;
        private LandingPage lp;
        private string currentClass;
        private string selectedDept;
        private CreationWizardWindow window;

        public CreationWizardPage3( CreationWizardWindow window, User user, LandingPage p, IList<string> departments, string dept) 
        {
            lp = p;
            this.departments = departments;
            this.selectedDept = dept;
            sqlHandler = new SQLHandlerControler();
            this.user = user;
            this.window = window;
            InitializeComponent();
            AddCoursesToComboBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreationWizardPage2(user, lp, window));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            selectedClass();
            this.NavigationService.Navigate(new CreationWizardPage4(window, user, lp, departments, selectedDept, classes, currentClass));
        }

        public void AddCoursesToComboBox()
        {
            int selectedDeptInt = Convert.ToInt32(departments.IndexOf(selectedDept));
            classes = new List<string>();
            IDataReader classList = sqlHandler.GetCourse(departments[selectedDeptInt]);
            while (classList.Read())
            {
                classes.Add(classList.GetValue(0).ToString());
                combo.Items.Add(classList.GetValue(0).ToString() + " " + classList.GetValue(1).ToString());
            }

        }

        public void selectedClass()
        {
            string selectedClass = classes[combo.SelectedIndex].ToString();
            currentClass = selectedClass;
        }
    }
}
