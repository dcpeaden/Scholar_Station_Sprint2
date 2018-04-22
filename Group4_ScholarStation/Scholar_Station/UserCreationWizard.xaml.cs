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
    /// Interaction logic for UserCreationWizard.xaml
    /// </summary>
    public partial class UserCreationWizard : Page
    {
        public UserCreationWizard()
        {
            InitializeComponent();
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            if(passwordBox1.Equals(passwordBox2.Text))
            {

            }
            else
            {
                MessageBox.Show("Your passwords do not match!");
                passwordBox1.Clear();
                passwordBox2.Clear();
            }
        }

        private void cancleButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
