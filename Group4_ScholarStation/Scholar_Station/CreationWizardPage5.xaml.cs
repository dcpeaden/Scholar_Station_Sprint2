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
        public CreationWizardPage5()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreationWizardPage4());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreationWizardWindow window = new CreationWizardWindow();
            window.Hide();
            this.NavigationService.Navigate(window);
            window.Close();
        }
    }
}
