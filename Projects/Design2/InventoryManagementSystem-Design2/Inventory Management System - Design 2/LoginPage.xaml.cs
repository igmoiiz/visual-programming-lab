using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Inventory_Management_System___Design_2
{
	public partial class LoginPage : Page
	{
		private DatabaseHelper dbHelper;

		public LoginPage()
		{
			InitializeComponent();
			dbHelper = new DatabaseHelper();
		}

		private void Login_Click(object sender, RoutedEventArgs e)
		{
			string username = txtUsername.Text;
			string password = txtPassword.Password; // Use Password property instead of Text

			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
			{
				MessageBox.Show("Please fill in all fields.");
				return;
			}

			try
			{
				// Use parameterized query to prevent SQL injection
				string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";

				using (MySqlConnection connection = new MySqlConnection(dbHelper.ConnectionString))
				{
					MySqlCommand command = new MySqlCommand(query, connection);
					command.Parameters.AddWithValue("@Username", username);
					command.Parameters.AddWithValue("@PasswordHash", password); // Ensure you hash the password before storing it

					connection.Open();
					int count = Convert.ToInt32(command.ExecuteScalar());

					if (count > 0)
					{
						MessageBox.Show("Login successful!");
						// Navigate to MainWindow
						MainWindow mainWindow = new MainWindow();
						mainWindow.Show();
						Application.Current.MainWindow.Close(); // Close the current window (if applicable)
					}
					else
					{
						MessageBox.Show("Invalid username or password.");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error during login: {ex.Message}");
			}
		}

		private void NavigateToSignup_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new SignupPage());
		}
	}
}