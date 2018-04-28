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

namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for CreationWizardPage3.xaml
    /// </summary>
    public partial class CreationWizardPage3 : Page
    {
        private IList<string> classes;
        private ISQLHandler sqlHandler;


        public CreationWizardPage3()
        {
            InitializeComponent();
            AddCoursesToComboBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreationWizardPage2());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreationWizardPage4());
        }

        public void AddCoursesToComboBox()
        {
            classes = new List<string>();
            IDataReader classList = sqlHandler.GetCourse(departments[departmentBox.SelectedIndex].ToString());
            while (classList.Read())
            {
                classes.Add(classList.GetValue(0).ToString());
                combo.Items.Add(classList.GetValue(0).ToString() + " " + classList.GetValue(1).ToString());
            }

        }
    }
}
