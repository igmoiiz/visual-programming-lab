using System.Windows;
using System.Windows.Controls;

namespace Inventory_Management_System
{
	public partial class UserManagement : Window
	{
		private DatabaseHelper dbHelper = new DatabaseHelper();

		public UserManagement()
		{
			InitializeComponent();
			LoadUsers();
		}

		private void LoadUsers()
		{
			string query = "SELECT Id, Username, Role FROM Users";
			UserListView.ItemsSource = dbHelper.ExecuteQuery(query).DefaultView;
		}

		private void AddUser_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			string username = UsernameTextBox.Text;
			string password = PasswordTextBox.Text;
			string role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

			if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password) && role != null)
			{
				string query = $"INSERT INTO Users (Username, Password, Role) VALUES ('{username}', '{password}', '{role}')";
				dbHelper.ExecuteNonQuery(query);
				LoadUsers();
				UsernameTextBox.Clear();
				PasswordTextBox.Clear();
				RoleComboBox.SelectedIndex = -1;
			}
		}
	}
}