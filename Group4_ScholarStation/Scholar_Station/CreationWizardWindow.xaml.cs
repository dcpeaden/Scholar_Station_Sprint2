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
using System.Windows.Shapes;

namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for CreationWizardWindow.xaml
    /// </summary>
    public partial class CreationWizardWindow : Window
    {
        private LandingPage lp;
        private User user;

        public CreationWizardWindow(User user, LandingPage lp)
        {
            this.user = user;
            this.lp = lp;
            Main.Content = new CreationWizardPage2(user, lp);
            InitializeComponent();
        }
    }
}
