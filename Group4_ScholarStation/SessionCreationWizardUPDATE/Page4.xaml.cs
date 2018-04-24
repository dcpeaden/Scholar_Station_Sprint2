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
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
            ConnectionControler conn = new ConnectionControler();
            conn.openConnection();
            SQLHandlerControler sql = new SQLHandlerControler();
            this.tutorContainer.Items.Add(sql.GetAllTutors());
        }

        private void finishClicked(object sender, RoutedEventArgs e)
        {
            
        }

        private void backClicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page3());
        }
    }
}
