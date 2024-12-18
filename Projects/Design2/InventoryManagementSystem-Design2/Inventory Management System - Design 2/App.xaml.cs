using System.Windows;
using System.Windows.Controls;

namespace Inventory_Management_System___Design_2
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			SignupPage signUpPage = new SignupPage();
			MainWindow mainWindow = new MainWindow();
			mainWindow.Content = signUpPage; // Set the initial content to SignUpPage
			mainWindow.Show();
		}
	}
}