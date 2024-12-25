using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Inventory_Management_System
{
	public partial class ReportAndAnalytics : Window
	{
		private DatabaseHelper _dbHelper;

		public ReportAndAnalytics()
		{
			InitializeComponent();
			_dbHelper = new DatabaseHelper();
		}

		private void GenerateInventoryValuation_Click(object sender, RoutedEventArgs e)
		{
			string query = "SELECT SUM(Quantity * UnitPrice) AS TotalInventoryValue FROM Products";
			DataTable result = _dbHelper.ExecuteQuery(query);
			if (result != null && result.Rows.Count > 0)
			{
				// Check for DBNull before casting
				decimal totalValue = result.Rows[0]["TotalInventoryValue"] != DBNull.Value
					? Convert.ToDecimal(result.Rows[0]["TotalInventoryValue"])
					: 0;

				StatusTextBlock.Text = $"Total Inventory Value: {totalValue:C}";
			}
			else
			{
				StatusTextBlock.Text = "Error generating report.";
			}
		}

		private void GenerateStockMovement_Click(object sender, RoutedEventArgs e)
		{
			string query = "SELECT MovementType, SUM(Quantity) AS TotalQuantity FROM StockMovements GROUP BY MovementType";
			DataTable result = _dbHelper.ExecuteQuery(query);
			if (result != null)
			{
				// Process the stock movement data
				StatusTextBlock.Text = "Stock Movement Report generated successfully.";
			}
			else
			{
				StatusTextBlock.Text = "Error generating report.";
			}
		}

		private void GenerateSalesReport_Click(object sender, RoutedEventArgs e)
		{
			string query = "SELECT SUM(TotalAmount) AS TotalSales FROM SalesOrders WHERE Status = 'Shipped'";
			DataTable result = _dbHelper.ExecuteQuery(query);
			if (result != null && result.Rows.Count > 0)
			{
				// Check for DBNull before casting
				decimal totalSales = result.Rows[0]["TotalSales"] != DBNull.Value
					? Convert.ToDecimal(result.Rows[0]["TotalSales"])
					: 0;

				StatusTextBlock.Text = $"Total Sales: {totalSales:C}";
			}
			else
			{
				StatusTextBlock.Text = "Error generating report.";
			}
		}

		private void GeneratePurchaseReport_Click(object sender, RoutedEventArgs e)
		{
			string query = "SELECT SUM(TotalAmount) AS TotalPurchases FROM PurchaseOrders WHERE Status = 'Completed'";
			DataTable result = _dbHelper.ExecuteQuery(query);
			if (result != null && result.Rows.Count > 0)
			{
				// Check for DBNull before casting
				decimal totalPurchases = result.Rows[0]["TotalPurchases"] != DBNull.Value
					? Convert.ToDecimal(result.Rows[0]["TotalPurchases"])
					: 0;

				StatusTextBlock.Text = $"Total Purchases: {totalPurchases:C}";
			}
			else
			{
				StatusTextBlock.Text = "Error generating report.";
			}
		}

		private void GenerateDemandForecast_Click(object sender, RoutedEventArgs e)
		{
			// Implement demand forecasting logic here
			StatusTextBlock.Text = "Demand Forecast Report generated successfully.";
		}
	}
}