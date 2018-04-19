using ScholarStation;
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

namespace Feedback_Form
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ISQLHandler handler;
        private User user;

        public MainWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            this.handler = new SQLHandlerControler();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            handler.LeaveSessionFeedback(user.Email, sessionIDBox.Text, feedbackBox.Text);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
