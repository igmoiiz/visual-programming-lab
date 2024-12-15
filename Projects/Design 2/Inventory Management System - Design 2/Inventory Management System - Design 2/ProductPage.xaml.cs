using Inventory_Management_System___Design_2;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Inventory_Management_System___Design_2
{
	public partial class ProductPage : Page
	{
		private DatabaseHelper dbHelper;

		public ProductPage()
		{
			InitializeComponent();
			dbHelper = new DatabaseHelper();
		}

		private void LoadProducts_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				DataTable products = dbHelper.ExecuteQuery("SELECT * FROM Products");
				dataGridProducts.ItemsSource = products.DefaultView;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading products: {ex.Message}");
			}
		}

		private void AddProduct_Click(object sender, RoutedEventArgs e)
		{
			string name = txtName.Text;
			string sku = txtSKU.Text;
			string unitPriceText = txtUnitPrice.Text;

			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(sku) || string.IsNullOrWhiteSpace(unitPriceText))
			{
				MessageBox.Show("Please fill in all fields.");
				return;
			}

			if (!decimal.TryParse(unitPriceText, out decimal unitPrice))
			{
				MessageBox.Show("Please enter a valid unit price.");
				return;
			}

			try
			{
				string query = $"INSERT INTO Products (Name, SKU, UnitPrice) VALUES ('{name}', '{sku}', {unitPrice})";
				dbHelper.ExecuteNonQuery(query);
				MessageBox.Show("Product added successfully!");
				txtName.Clear();
				txtSKU.Clear();
				txtUnitPrice.Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error adding product: {ex.Message}");
			}
		}
	}
}