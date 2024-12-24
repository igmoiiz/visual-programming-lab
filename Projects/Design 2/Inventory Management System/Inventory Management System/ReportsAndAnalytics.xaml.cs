using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Inventory_Management_System
{
	public partial class ReportsAndAnalytics : Window
	{
		private DatabaseHelper dbHelper = new DatabaseHelper();

		public ReportsAndAnalytics()
		{
			InitializeComponent();
		}

		private void GenerateInventoryReport_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			string query = "SELECT p.Id, p.Name AS ProductName, SUM(sm.Quantity) AS TotalQuantity " +
						   "FROM Products p " +
						   "LEFT JOIN StockMovements sm ON p.Id = sm.Product Id " +
						   "GROUP BY p.Id, p.Name";
			DataTable dt = dbHelper.ExecuteQuery(query);
			ReportListView.ItemsSource = dt.DefaultView;
		}
	}
}