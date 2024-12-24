using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Inventory_Management_System
{
	public partial class ProductsPage : Window
	{
		private DatabaseHelper dbHelper = new DatabaseHelper();

		public ProductsPage()
		{
			InitializeComponent();
			LoadProducts();
		}

		private void LoadProducts()
		{
			string query = "SELECT ProductID AS Id, Name, SKU, Category, Quantity, UnitPrice, Barcode FROM Products";
			ProductListView.ItemsSource = dbHelper.ExecuteQuery(query)?.DefaultView;
		}

		private void AddProduct_Click(object sender, RoutedEventArgs e)
		{
			string name = ProductNameTextBox.Text;
			string sku = SKUTextBox.Text;
			string category = CategoryTextBox.Text;
			decimal unitPrice;
			int quantity;
			string barcode = BarcodeTextBox.Text;

			// Validate input
			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(sku) || string.IsNullOrWhiteSpace(category) ||
				!int.TryParse(ProductQuantityTextBox.Text, out quantity) || !decimal.TryParse(UnitPriceTextBox.Text, out unitPrice))
			{
				MessageBox.Show("Please fill in all fields correctly.");
				return;
			}

			// Construct the SQL query
			string query = $"INSERT INTO Products (Name, SKU, Category, Quantity, UnitPrice, Barcode) VALUES ('{name}', '{sku}', '{category}', {quantity}, {unitPrice}, '{barcode}')";
			dbHelper.ExecuteNonQuery(query);
			LoadProducts(); // Refresh the product list
			ClearInputFields(); // Clear input fields after adding
		}

		private void EditProduct_Click(object sender, RoutedEventArgs e)
		{
			if (ProductListView.SelectedItem is DataRowView selectedProduct)
			{
				int productId = Convert.ToInt32(selectedProduct["Id"]);
				string name = ProductNameTextBox.Text;
				string sku = SKUTextBox.Text;
				string category = CategoryTextBox.Text;
				decimal unitPrice;
				int quantity;
				string barcode = BarcodeTextBox.Text;

				// Validate input
				if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(sku) || string.IsNullOrWhiteSpace(category) ||
					!int.TryParse(ProductQuantityTextBox.Text, out quantity) || !decimal.TryParse(UnitPriceTextBox.Text, out unitPrice))
				{
					MessageBox.Show("Please fill in all fields correctly.");
					return;
				}

				// Construct the SQL query
				string query = $"UPDATE Products SET Name = '{name}', SKU = '{sku}', Category = '{category}', Quantity = {quantity}, UnitPrice = {unitPrice}, Barcode = '{barcode}' WHERE ProductID = {productId}";
				dbHelper.ExecuteNonQuery(query);
				LoadProducts(); // Refresh the product list
				ClearInputFields(); // Clear input fields after editing
			}
			else
			{
				MessageBox.Show("Please select a product to edit.");
			}
		}

		private void DeleteProduct_Click(object sender, RoutedEventArgs e)
		{
			if (ProductListView.SelectedItem is DataRowView selectedProduct)
			{
				int productId = Convert.ToInt32(selectedProduct["Id"]);
				string query = $"DELETE FROM Products WHERE ProductID = {productId}";
				dbHelper.ExecuteNonQuery(query);
				LoadProducts(); // Refresh the product list
			}
			else
			{
				MessageBox.Show("Please select a product to delete.");
			}
		}

		private void ProductListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ProductListView.SelectedItem is DataRowView selectedProduct)
			{
				ProductNameTextBox.Text = selectedProduct["Name"].ToString();
				SKUTextBox.Text = selectedProduct["SKU"].ToString();
				CategoryTextBox.Text = selectedProduct["Category"].ToString();
				ProductQuantityTextBox.Text = selectedProduct["Quantity"].ToString();
				UnitPriceTextBox.Text = selectedProduct["UnitPrice"].ToString();
				BarcodeTextBox.Text = selectedProduct["Barcode"].ToString();
			}
		}

		private void ClearInputFields()
		{
			ProductNameTextBox.Clear();
			SKUTextBox.Clear();
			CategoryTextBox.Clear();
			ProductQuantityTextBox.Clear();
			UnitPriceTextBox.Clear();
			BarcodeTextBox.Clear();
		}
	}
}