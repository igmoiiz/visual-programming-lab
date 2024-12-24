using Inventory_Management_System;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Controls;

namespace Inventory_Management_System
{
	public partial class InterfacePage : Window
	{
		public InterfacePage()
		{
			InitializeComponent();
		}

		private void DashboardButton_Click(object sender, RoutedEventArgs e)
		{
			DashboardPage dashboardPage = new DashboardPage();
			dashboardPage.Show();
		}

		private void ProductManagementButton_Click(object sender, RoutedEventArgs e)
		{
			ProductsPage productsPage = new ProductsPage();
			productsPage.Show();
		}

		private void InventoryTrackingButton_Click(object sender, RoutedEventArgs e)
		{
			InventoryTracking inventoryPage = new InventoryTracking();
			inventoryPage.Show();
		}

		private void PurchaseOrderManagementButton_Click(object sender, RoutedEventArgs e)
		{
			PurchaseOrderManagement purchaseOrderManagement = new PurchaseOrderManagement();
			purchaseOrderManagement.Show();
		}

		private void SalesOrderManagementButton_Click(object sender, RoutedEventArgs e)
		{
			SalesOrderManagement salesOrderManagement = new SalesOrderManagement();
			salesOrderManagement.Show();
		}

		private void StockMovementButton_Click(object sender, RoutedEventArgs e)
		{
			StockMovement stockMovement = new StockMovement();
			stockMovement.Show();
		}

		private void SupplierManagementButton_Click(object sender, RoutedEventArgs e)
		{
			SupplierManagement supplierManagement = new SupplierManagement();
			supplierManagement.Show();
		}

		private void CustomerManagementButton_Click(object sender, RoutedEventArgs e)
		{
			CustomerManagement customerManagement = new CustomerManagement();
			customerManagement.Show();
		}

		private void ReportsAndAnalyticsButton_Click(object sender, RoutedEventArgs e)
		{
			ReportsAndAnalytics reportAndAnalytics = new ReportsAndAnalytics();
			reportAndAnalytics.Show();
		}

		private void ReorderAlertsButton_Click(object sender, RoutedEventArgs e)
		{
			ReorderAlerts reorderAlerts = new ReorderAlerts();
			reorderAlerts.Show();
		}

		private void UserManagementButton_Click(object sender, RoutedEventArgs e)
		{
			UserManagement userManagement = new UserManagement();
			userManagement.Show();
		}

		private void AuditLogsButton_Click(object sender, RoutedEventArgs e)
		{
			AuditLogs auditLogs = new AuditLogs();
			auditLogs.Show();
		}

		private void BarcodeScanningButton_Click(object sender, RoutedEventArgs e)
		{
			BarcodeScanning barcodeScanning = new BarcodeScanning();
			barcodeScanning.Show();
		}

		private void NotificationsCenterButton_Click(object sender, RoutedEventArgs e)
		{
			NotificationsCenter notificationsCenter = new NotificationsCenter();
			notificationsCenter.Show();
		}

		private void SettingsButton_Click(object sender, RoutedEventArgs e)
		{
			Settings settings = new Settings();
			settings.Show();
		}

		private void HelpAndSupportButton_Click(object sender, RoutedEventArgs e)
		{
			HelpAndSupport helpAndSupport = new HelpAndSupport();
			helpAndSupport.Show();
		}
		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			// Logic to exit the application
			Application.Current.Shutdown();
		}
	}
}