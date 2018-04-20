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

namespace SessionCreationWizardUPDATE
{
    /// <summary>
    /// Interaction logic for WizardWindow.xaml
    /// </summary>
    public partial class WizardWindow : Window
    {
        private List<string> sessionTypes = new List<string> { "Tutor Session", "Study Session" };
        public WizardWindow()
        {
            InitializeComponent();
            _combo.Width = 20;
            foreach (var item in sessionTypes)
            {
                _combo.Items.Add(item);
            }
        }
    }
}
