using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Scholar_Station
{
    public partial class IntroPage : Form
    {
        public IntroPage()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            this.Show();
            //this.NavigationService.Navigate(new logInFrame());
        }

        private void SignInImageButton_Click(object sender, EventArgs e)
        {
            this.Show();
            //mainWindowFrame.NavigationService.Navigate(new logInFrame());
        }
    }
}
