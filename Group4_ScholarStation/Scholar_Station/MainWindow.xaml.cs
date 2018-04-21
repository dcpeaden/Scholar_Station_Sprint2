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
            InitializeComponent();
            mainWindowFrame.NavigationService.Navigate(new IntroPage1());
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