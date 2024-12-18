using Inventory_Management_System___Design_2;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Inventory_Management_System___Design_2
{
	public partial class SignupPage : Page
	{
		private DatabaseHelper dbHelper;

		public SignupPage()
		{
			InitializeComponent();
			dbHelper = new DatabaseHelper();
		}

		private void Signup_Click(object sender, RoutedEventArgs e)
		{
			string username = txtUsername.Text;
			string password = txtPassword.Password; // Use Password property instead of Text
			string role = txtRole.Text;

			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
			{
				MessageBox.Show("Please fill in all fields.");
				return;
			}

			try
			{
				string query = $"INSERT INTO Users (Username, PasswordHash, Role) VALUES ('{username}', '{password}', '{role}')";
				dbHelper.ExecuteNonQuery(query);
				MessageBox.Show("Signup successful! Please log in.");
				NavigationService.Navigate(new LoginPage());
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error during signup: {ex.Message}");
			}
		}

		private void NavigateToLogin_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new LoginPage());
		}
	}
}