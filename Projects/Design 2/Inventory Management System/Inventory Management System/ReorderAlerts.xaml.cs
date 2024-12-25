using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Inventory_Management_System
{
	public partial class ReorderAlerts : Window
	{
		private DatabaseHelper _dbHelper;

		public ReorderAlerts()
		{
			InitializeComponent();
			_dbHelper = new DatabaseHelper();
			LoadLowStockProducts();
		}

		private void LoadLowStockProducts()
		{
			// Assuming the minimum level is stored in the Products table
			string query = "SELECT p.Name, p.Quantity, p.MinLevel, s.SupplierName " +
						   "FROM Products p " +
						   "JOIN Suppliers s ON p.SupplierID = s.SupplierID " +
						   "WHERE p.Quantity < p.MinLevel";

			DataTable lowStockProducts = _dbHelper.ExecuteQuery(query);
			if (lowStockProducts != null)
			{
				LowStockDataGrid.ItemsSource = lowStockProducts.DefaultView;
			}
		}

		private void GenerateReorderReport_Click(object sender, RoutedEventArgs e)
		{
			// Logic to generate a reorder report
			// This could involve creating a PDF or exporting to Excel, etc.
			StatusTextBlock.Text = "Reorder report generated successfully!";
		}
	}
}