using DataAccessControler;
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

namespace SessionCreationWizardUPDATE
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
            SQLHandlerControler sql = new SQLHandlerControler();
            classContainer.Items.Add(sql.GetAllCourses());
        }

        private void NextClicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page4());
        }

        private void BackClicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page2());
        }
    }
}
