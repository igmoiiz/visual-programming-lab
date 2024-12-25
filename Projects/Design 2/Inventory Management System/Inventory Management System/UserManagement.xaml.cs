using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Inventory_Management_System
{
	public partial class UserManagement : Window
	{
		private DatabaseHelper _dbHelper;

		public UserManagement()
		{
			InitializeComponent();
			_dbHelper = new DatabaseHelper();
			LoadUsers();
			LoadAuditLogs();
		}

		private void LoadUsers()
		{
			string query = "SELECT UserID, Username, Role, CreatedAt FROM Users";
			DataTable users = _dbHelper.ExecuteQuery(query);
			if (users != null)
			{
				UserDataGrid.ItemsSource = users.DefaultView;
			}
		}

		private void LoadAuditLogs()
		{
			string query = "SELECT Action, TableAffected, ActionTime FROM AuditLogs ORDER BY ActionTime DESC";
			DataTable auditLogs = _dbHelper.ExecuteQuery(query);
			if (auditLogs != null)
			{
				AuditLogDataGrid.ItemsSource = auditLogs.DefaultView;
			}
		}

		private void AddUser_Click(object sender, RoutedEventArgs e)
		{
			string username = UsernameTextBox.Text;
			string password = PasswordBox.Password; // Use Password property instead of Text
			string role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
			{
				MessageBox.Show("Please fill in all fields.");
				return;
			}

			string passwordHash = HashPassword(password);
			string query = "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@Username, @PasswordHash, @Role)";
			var parameters = new { Username = username, PasswordHash = passwordHash, Role = role };

			_dbHelper.ExecuteNonQuery(query, parameters);
			LoadUsers();
			LogAction($"Added user {username}", "Users");
		}

		private void UpdateUser_Click(object sender, RoutedEventArgs e)
		{
			if (UserDataGrid.SelectedItem is DataRowView selectedUser )
            {
				int userId = Convert.ToInt32(selectedUser["UserID"]);
				string username = UsernameTextBox.Text;
				string password = PasswordBox.Password;
				string role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

				// Only hash the password if it's not empty
				string passwordHash = string.IsNullOrEmpty(password) ? null : HashPassword(password);
				string query = "UPDATE Users SET Username = @Username, Role = @Role" +
							   (passwordHash != null ? ", PasswordHash = @PasswordHash" : "") +
							   " WHERE UserID = @User ID";

				var parameters = new
				{
					Username = username,
					Role = role,
					PasswordHash = passwordHash,
					UserID = userId
				};

				_dbHelper.ExecuteNonQuery(query, parameters);
				LoadUsers();
				LogAction($"Updated user {username}", "Users");
			}

			else
			{
				MessageBox.Show("Please select a user to update.");
			}
		}

		private void DeleteUser_Click(object sender, RoutedEventArgs e)
		{
			if (UserDataGrid.SelectedItem is DataRowView selectedUser )
            {
				int userId = Convert.ToInt32(selectedUser["UserID"]);
				string username = selectedUser["Username"].ToString();

				string query = "DELETE FROM Users WHERE UserID = @User ID";
				var parameters = new { UserID = userId };

				_dbHelper.ExecuteNonQuery(query, parameters);
				LoadUsers();
				LogAction($"Deleted user {username}", "Users");
			}

			else
			{
				MessageBox.Show("Please select a user to delete.");
			}
		}

		private void LogAction(string action, string tableAffected)
		{
			// Assuming you have a way to get the current user's ID
			int currentUserId = 1; // Replace with actual logic to get the current user's ID
			string query = "INSERT INTO AuditLogs (User ID, Action, TableAffected) VALUES (@User ID, @Action, @TableAffected)";
			var parameters = new { UserID = currentUserId, Action = action, TableAffected = tableAffected };

			_dbHelper.ExecuteNonQuery(query, parameters);
			LoadAuditLogs();
		}

		private string HashPassword(string password)
		{
			using (var sha256 = SHA256.Create())
			{
				byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
				return Convert.ToBase64String(bytes);
			}
		}

		private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (UserDataGrid.SelectedItem is DataRowView selectedUser )
            {
				UsernameTextBox.Text = selectedUser["Username"].ToString();
				PasswordBox.Password = ""; // Clear password box for security
				RoleComboBox.SelectedItem = RoleComboBox.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == selectedUser["Role"].ToString());
			}
		}
	}
}