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
using SQLHandler;

namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for CreationWizardPage2.xaml
    /// </summary>
    
    public partial class CreationWizardPage2 : Page
    {
        private IList<string> departments;
        private ISQLHandler sqlHandler;

        public CreationWizardPage2()
        {
            InitializeComponent();
            AddDepartmentsToComboBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreationWizard());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreationWizardPage3());
        }

        public void AddDepartmentsToComboBox()
        {
            departments = new List<string>();
            IDataReader departmentList = sqlHandler.GetDepartment();
            while (departmentList.Read())
            {
                departments.Add(departmentList.GetValue(0).ToString());
                combo.Items.Add(departmentList.GetValue(0).ToString() + " " + departmentList.GetValue(1).ToString());
            }
        }
    }
}
