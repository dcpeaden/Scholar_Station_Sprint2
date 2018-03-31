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
        private System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private SplashScreenWindow splashWindow;
        public MainWindow()
        {
            this.Hide();
            InitializeComponent();
            splashWindow = new SplashScreenWindow();
            splashWindow.Show();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 7);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            splashWindow.Hide();
            this.Show();
            mainWindowFrame.NavigationService.Navigate(new logInFrame());
            dispatcherTimer.Stop();
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