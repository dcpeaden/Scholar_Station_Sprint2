using ScholarStation;
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
    /// Interaction logic for CreationWizardPage4.xaml
    /// </summary>
    public partial class CreationWizardPage4 : Page
    {
        private IList<string> addDate;
        private IList<string> departments;
        private IList<string> classes;
        private IDate date;
        private User user;
        private LandingPage lp;
        private string selectedClass;
        private string currentDate;

        public CreationWizardPage4(User user, LandingPage p, IList<string> departments, IList<string> classes, string selectedClass)
        {
            lp = p;
            this.departments = departments;
            this.classes = classes;
            this.user = user;
            this.selectedClass = selectedClass;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreationWizardPage3(user, lp, departments));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            selectedDateIndex();
            this.NavigationService.Navigate(new CreationWizardPage5(user, lp, departments, classes, selectedClass, addDate, currentDate));
        }

        public void FillDateBox()
        {
            date = new Date();
            addDate = date.FillDate();
            foreach (var date in addDate)
            {
                combo.Items.Add(date);
            }
        }

        public void selectedDateIndex()
        {
            string newDate = addDate[combo.SelectedIndex].ToString();
            currentDate = newDate;
        }
    }
}
