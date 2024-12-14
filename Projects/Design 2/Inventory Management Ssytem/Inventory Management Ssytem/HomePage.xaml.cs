using InventoryManagementSystem;
using System.Windows;

namespace WpfLoginSignupApp
{
	public partial class HomeWindow : Window
	{
		public HomeWindow()
		{
			InitializeComponent();
		}

		private void DashboardButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Dashboard clicked!");
			// Navigate to Dashboard Page
		}

		private void ProductManagementButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Product Management clicked!");
			// Navigate to Product Management Page
		}

		private void InventoryTrackingButton_Click(object sender, RoutedEventArgs e)
		{
			InventoryTrackingWindow inventoryTrackingWindow = new InventoryTrackingWindow();
			inventoryTrackingWindow.Show();
			this.Close();
		}

		private void PurchaseOrderManagementButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Purchase Order Management clicked!");
			// Navigate to Purchase Order Management Page
		}

		private void SalesOrderManagementButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Sales Order Management clicked!");
			// Navigate to Sales Order Management Page
		}

		private void StockMovementButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Stock Movement clicked!");
			// Navigate to Stock Movement Page
		}

		private void SupplierManagementButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Supplier Management clicked!");
			// Navigate to Supplier Management Page
		}

		private void CustomerManagementButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Customer Management clicked!");
			// Navigate to Customer Management Page
		}

		private void ReportsAnalyticsButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Reports and Analytics clicked!");
			// Navigate to Reports and Analytics Page
		}

		private void ReorderAlertsButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Reorder Alerts clicked!");
			// Navigate to Reorder Alerts Page
		}

		private void UserManagementButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("User  Management clicked!");
			// Navigate to User Management Page
		}

		private void AuditLogsButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Audit Logs clicked!");
			// Navigate to Audit Logs Page
		}

		private void BarcodeScanningButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Barcode Scanning clicked!");
			// Navigate to Barcode Scanning Page
		}

		private void NotificationsCenterButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Notifications Center clicked!");
			// Navigate to Notifications Center Page
		}

		private void SettingsConfigurationButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Settings and Configuration clicked!");
			// Navigate to Settings and Configuration Page
		}

		private void HelpSupportButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Help and Support clicked!");
			// Navigate to Help and Support Page
		}

		private void BackupRestoreButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Backup and Restore clicked!");
			// Navigate to Backup and Restore Page
		}

		private void IntegrationSettingsButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Integration Settings clicked!");
			// Navigate to Integration Settings Page
		}
	}
}