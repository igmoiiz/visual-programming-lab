using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Inventory_Management_System
{
	public partial class InventoryTracking : Window
	{
		private DatabaseHelper dbHelper = new DatabaseHelper();

		public InventoryTracking()
		{
			InitializeComponent();
			LoadProducts();
		}

		private void LoadProducts()
		{
			string query = "SELECT ProductID, Name FROM Products";
			DataTable products = dbHelper.ExecuteQuery(query);
			if (products != null)
			{
				ProductComboBox.ItemsSource = products.DefaultView;
				ProductComboBox.DisplayMemberPath = "Name";
				ProductComboBox.SelectedValuePath = "ProductID";
			}
		}

		private void ProductComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ProductComboBox.SelectedValue != null)
			{
				int productId = (int)ProductComboBox.SelectedValue;
				LoadStockLevels(productId);
				LoadBatchSerialTracking(productId);
				LoadRecentStockMovements(productId);
			}
		}

		private void LoadStockLevels(int productId)
		{
			string query = $"SELECT l.LocationName, i.Quantity AS StockQuantity FROM Inventory i " +
						   $"JOIN Locations l ON i.LocationID = l.LocationID " +
						   $"WHERE i.ProductID = {productId}";
			DataTable stockLevels = dbHelper.ExecuteQuery(query);
			LocationStockListView.ItemsSource = stockLevels.DefaultView;
		}

		private void LoadBatchSerialTracking(int productId)
		{
			string query = $"SELECT BatchNumber, SerialNumber, Quantity AS StockQuantity FROM Inventory " +
						   $"WHERE ProductID = {productId}";
			DataTable batchSerials = dbHelper.ExecuteQuery(query);
			BatchSerialListView.ItemsSource = batchSerials.DefaultView;
		}

		private void LoadRecentStockMovements(int productId)
		{
			string query = $"SELECT MovementDate, p.Name AS ProductName, MovementType, sm.Quantity AS MovementQuantity, Description " +
						   $"FROM StockMovements sm " +
						   $"JOIN Products p ON sm.ProductID = p.ProductID " +
						   $"WHERE sm.ProductID = {productId} " +
						   $"ORDER BY MovementDate DESC";
			DataTable stockMovements = dbHelper.ExecuteQuery(query);
			StockMovementListView.ItemsSource = stockMovements.DefaultView;
		}
	}
}