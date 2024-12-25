using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Inventory_Management_System
{
	public partial class Settings : Window
	{
		private DatabaseHelper _dbHelper;

		public Settings()
		{
			InitializeComponent();
			_dbHelper = new DatabaseHelper();
			LoadIntegrationLogs();
		}

		private void LoadIntegrationLogs()
		{
			string query = "SELECT Timestamp, Action, Status, Description FROM IntegrationLogs ORDER BY Timestamp DESC";
			DataTable logs = _dbHelper.ExecuteQuery(query);
			if (logs != null)
			{
				IntegrationLogDataGrid.ItemsSource = logs.DefaultView;
			}
		}

		private void SaveSettings_Click(object sender, RoutedEventArgs e)
		{
			string apiKey = ApiKeyTextBox.Text.Trim();
			string syncStatus = (SyncStatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

			if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(syncStatus))
			{
				MessageBox.Show("Please fill in all fields.");
				return;
			}

			// Save the API key and sync status to the database or configuration file
			// This is a placeholder for the actual saving logic
			// You may want to create a table for settings or use a configuration file

			// Example: Save to a hypothetical Settings table
			string query = "INSERT INTO Settings (ApiKey, SyncStatus) VALUES (@ApiKey, @SyncStatus) ON DUPLICATE KEY UPDATE SyncStatus = @SyncStatus";
			var parameters = new { ApiKey = apiKey, SyncStatus = syncStatus };

			_dbHelper.ExecuteNonQuery(query, parameters);
			StatusTextBlock.Text = "Settings saved successfully!";
		}
	}
}