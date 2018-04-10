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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scholar_Station
{
	/// <summary>
	/// Interaction logic for UserHome.xaml
	/// </summary>
	public partial class UserHome : Page
	{
		private User user;

		public UserHome(User user)
		{
			this.user = user;
			InitializeComponent();
			welcome.Content = "Welcome, " + user.Email + "!";
			populateSessionsComboBox(tutorSessionsSelect);
			populateSessionsComboBox(attendeeSessionsSelect);
		}

		private void createSession_Click(object sender, RoutedEventArgs e)
		{
			this.NavigationService.Navigate(new tutorPage(user));
		}

		private void joinSession_Click(object sender, RoutedEventArgs e)
		{
			this.NavigationService.Navigate(new joinSessionFrame(user));
		}

		private void logOut_Click(object sender, RoutedEventArgs e)
		{
			this.NavigationService.Navigate(new logInFrame());
		}

		private void populateSessionsComboBox(ComboBox box)
		{
			box.Items.Add("--Select Session--");
			box.SelectedIndex = 0;
		}
	}
}
