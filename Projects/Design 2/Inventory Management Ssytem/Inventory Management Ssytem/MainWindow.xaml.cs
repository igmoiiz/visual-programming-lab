using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfLoginSignupApp
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			string username = UsernameTextBox.Text;
			string password = PasswordBox.Password;

			// Here you can add your authentication logic
			if (username == "admin" && password == "password") // Example credentials
			{
				HomeWindow homeWindow = new HomeWindow();
				homeWindow.Show();
				this.Close(); // Close the login window
			}
			else
			{
				MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void SignUpButton_Click(object sender, RoutedEventArgs e)
		{
			SignupWindow signupWindow = new SignupWindow();
			signupWindow.Show();
			this.Close(); // Close the login window
		}
	}
}