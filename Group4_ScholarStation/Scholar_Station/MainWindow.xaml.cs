using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;


namespace Scholar_Station
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            InitializeComponent();
            this.Hide();
            IntroPage introPage = new IntroPage(this);
            mainWindowFrame.NavigationService.Navigate(new logInFrame());
            introPage.Show();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            bool wasCodeClosed = new StackTrace().GetFrames().FirstOrDefault(x => x.GetMethod() == typeof(Window).GetMethod("Close")) != null;
            if (wasCodeClosed)
            {
                this.Close();
            }
            else
            {
                Application.Current.Shutdown();
            }

            base.OnClosing(e);
        }
    }
}