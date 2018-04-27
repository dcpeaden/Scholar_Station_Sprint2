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
using System.Windows.Shapes;

namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for FeedbackForm.xaml
    /// </summary>
    public partial class FeedbackForm : Window
    {
        ISQLHandler handler;
        private User user;
        private string sessionID;

        public FeedbackForm(User user, string currentID)
        {
            InitializeComponent();
            this.user = user;
            this.handler = new SQLHandlerControler();
            this.sessionID = currentID;
        }

        public void SendFeedback()
        {
            if (String.IsNullOrEmpty(feedbackBox.Text))
            {
                MessageBox.Show("You must enter feedback!");
            }
            else
            {
                handler.LeaveSessionFeedback(user.Email, sessionID, feedbackBox.Text);
                handler.CloseSession(this.sessionID);
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
