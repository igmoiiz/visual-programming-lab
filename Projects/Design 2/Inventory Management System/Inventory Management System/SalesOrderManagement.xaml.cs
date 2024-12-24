using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Inventory_Management_System
{
	public partial class SalesOrderManagement : Window
	{
		private DatabaseHelper dbHelper = new DatabaseHelper();
		private DataTable selectedProducts = new DataTable();

		public SalesOrderManagement()
		{
			InitializeComponent();
			InitializeSelectedProductsTable();
			LoadProducts();
			LoadRecentSalesOrders();
		}

		private void InitializeSelectedProductsTable()
		{
			selectedProducts.Columns.Add("ProductID", typeof(int));
			selectedProducts.Columns.Add("Name", typeof(string));
			selectedProducts.Columns.Add("UnitPrice", typeof(decimal));
			selectedProducts.Columns.Add("Quantity", typeof(int));
		}

		private void LoadProducts()
		{
			// Load products into ProductListView
			string query = "SELECT ProductID, Name, UnitPrice FROM Products";
			DataTable products = dbHelper.ExecuteQuery(query);
			ProductListView.ItemsSource = products.DefaultView;
		}

		private void LoadRecentSalesOrders()
		{
			// Load recent sales orders into SalesOrderListView
			string query = "SELECT SalesOrderID, CustomerName, OrderDate, Status, TotalAmount FROM SalesOrders ORDER BY OrderDate DESC";
			DataTable salesOrders = dbHelper.ExecuteQuery(query);
			SalesOrderListView.ItemsSource = salesOrders.DefaultView;
		}

		private void ProductListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Handle product selection change if needed
		}

		private void AddProduct_Click(object sender, RoutedEventArgs e)
		{
			if (ProductListView.SelectedItem is DataRowView selectedProduct && int.TryParse(QuantityTextBox.Text, out int quantity) && quantity > 0)
			{
				// Add selected product to the selected products table
				selectedProducts.Rows.Add(selectedProduct["ProductID"], selectedProduct["Name"], selectedProduct["UnitPrice"], quantity);
				UpdateTotalAmount();
				// Optionally clear the selection and quantity input
				ProductListView.SelectedItem = null;
				QuantityTextBox.Clear();
			}
			else
			{
				MessageBox.Show("Please select a product and enter a valid quantity.");
			}
		}

		private void UpdateTotalAmount()
		{
			decimal totalAmount = 0;
			foreach (DataRow row in selectedProducts.Rows)
			{
				totalAmount += (decimal)row["UnitPrice"] * (int)row["Quantity"];
			}
			TotalAmountTextBox.Text = totalAmount.ToString("C2");
		}

		private void CreateSalesOrder_Click(object sender, RoutedEventArgs e)
		{
			// Logic to create a sales order
			string insertOrderQuery = "INSERT INTO SalesOrders (CustomerName, OrderDate, Status, TotalAmount) VALUES (@CustomerName, @OrderDate, @Status, @TotalAmount)";
			var parameters = new
			{
				CustomerName = CustomerNameTextBox.Text,
				OrderDate = DateTime.Now,
				Status = OrderStatusComboBox.SelectedItem.ToString(),
				TotalAmount = decimal.Parse(TotalAmountTextBox.Text, System.Globalization.NumberStyles.Currency)
			};
			dbHelper.ExecuteNonQuery(insertOrderQuery, parameters);

			// Optionally, save the selected products to the SalesOrderDetails table
			int salesOrderId = GetLastInsertedSalesOrderId();
			foreach (DataRow row in selectedProducts.Rows)
			{
				string insertDetailQuery = "INSERT INTO SalesOrderDetails (SalesOrderID, ProductID, Quantity, UnitPrice) VALUES (@SalesOrderID, @ProductID, @Quantity, @UnitPrice)";
				var detailParameters = new
				{
					SalesOrderID = salesOrderId,
					ProductID = row["ProductID"],
					Quantity = row["Quantity"],
					UnitPrice = row["UnitPrice"]
				};
				dbHelper.ExecuteNonQuery(insertDetailQuery, detailParameters);
			}

			MessageBox.Show("Sales order created successfully!");
			LoadRecentSalesOrders();
		}

		private int GetLastInsertedSalesOrderId()
		{
			string query = "SELECT LAST_INSERT_ID()";
			return Convert.ToInt32(dbHelper.ExecuteScalar(query));
		}
	}
}