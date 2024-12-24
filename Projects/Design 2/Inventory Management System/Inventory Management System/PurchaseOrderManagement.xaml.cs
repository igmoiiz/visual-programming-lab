using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Inventory_Management_System
{
	public partial class PurchaseOrderManagement : Window
	{
		private DatabaseHelper dbHelper = new DatabaseHelper();
		private DataTable selectedProducts = new DataTable();

		public PurchaseOrderManagement()
		{
			InitializeComponent();
			LoadSuppliers();
			InitializeSelectedProductsTable();
		}

		private void LoadSuppliers()
		{
			// Load suppliers into SupplierComboBox
			string query = "SELECT SupplierID, SupplierName FROM Suppliers";
			DataTable suppliers = dbHelper.ExecuteQuery(query);
			SupplierComboBox.ItemsSource = suppliers.DefaultView;
			SupplierComboBox.DisplayMemberPath = "SupplierName";
			SupplierComboBox.SelectedValuePath = "SupplierID";
		}

		private void InitializeSelectedProductsTable()
		{
			selectedProducts.Columns.Add("ProductID", typeof(int));
			selectedProducts.Columns.Add("Name", typeof(string));
			selectedProducts.Columns.Add("UnitPrice", typeof(decimal));
			selectedProducts.Columns.Add("Quantity", typeof(int));
		}

		private void SupplierComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Logic to handle supplier selection change if needed
		}

		private void ProductListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Handle product selection change
			if (ProductListView.SelectedItem is DataRowView selectedProduct)
			{
				// Example logic to display selected product details
				// You can set the unit price or any other details as needed
				decimal unitPrice = (decimal)selectedProduct["UnitPrice"];
				// Example: UnitPriceTextBox.Text = unitPrice.ToString("C2");
			}
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

		private void CreatePurchaseOrder_Click(object sender, RoutedEventArgs e)
		{
			// Logic to create a purchase order
			// This would typically involve saving the order details to the database
			// and possibly the selected products as well
			string insertOrderQuery = "INSERT INTO PurchaseOrders (SupplierID, OrderDate, Status, TotalAmount) VALUES (@SupplierID, @OrderDate, @Status, @TotalAmount)";
			var parameters = new
			{
				SupplierID = SupplierComboBox.SelectedValue,
				OrderDate = DateTime.Now,
				Status = OrderStatusComboBox.SelectedItem.ToString(),
				TotalAmount = decimal.Parse(TotalAmountTextBox.Text, System.Globalization.NumberStyles.Currency)
			};
			dbHelper.ExecuteNonQuery(insertOrderQuery, parameters);

			// Optionally, you can also save the selected products to a separate table
			MessageBox.Show("Purchase order created successfully!");
		}
	}
}