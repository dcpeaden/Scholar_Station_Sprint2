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

        public void SendFeedback()
        {
            if (String.IsNullOrEmpty(sessionIDBox.Text))
            {
                 MessageBox.Show("You must enter session id!");
            }
            else if(String.IsNullOrEmpty(feedbackBox.Text))
            {
                MessageBox.Show("You must enter feedback!");
            }
            else
            {
                handler.LeaveSessionFeedback(user.Email, sessionIDBox.Text, feedbackBox.Text);
                MessageBox.Show("Feedback Sent");
                this.Close();
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            SendFeedback();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
