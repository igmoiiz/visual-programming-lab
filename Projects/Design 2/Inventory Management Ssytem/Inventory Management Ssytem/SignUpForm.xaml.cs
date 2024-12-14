using System.Windows;

namespace WpfLoginSignupApp
{
	public partial class SignupWindow : Window
	{
		public SignupWindow()
		{
			InitializeComponent();
		}

		private void SignUpButton_Click(object sender, RoutedEventArgs e)
		{
			string username = UsernameTextBox.Text;
			string password = PasswordBox.Password;

			// Here you can add your user registration logic, such as saving the username and password to a database or a file. For demonstration purposes, we'll just show a message box indicating successful signup.

			MessageBox.Show("Sign up successful! You can now log in.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			this.Close(); // Close the signup window
		}
	}
}