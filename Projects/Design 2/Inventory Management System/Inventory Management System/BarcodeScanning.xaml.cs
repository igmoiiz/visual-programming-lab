using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Inventory_Management_System
{
	public partial class BarcodeScanning : Window
	{
		private DatabaseHelper _dbHelper;

		public BarcodeScanning()
		{
			InitializeComponent();
			_dbHelper = new DatabaseHelper();
		}

		private void SearchProduct_Click(object sender, RoutedEventArgs e)
		{
			string barcode = BarcodeTextBox.Text.Trim();
			if (string.IsNullOrEmpty(barcode))
			{
				MessageBox.Show("Please enter a barcode.");
				return;
			}

			LoadProductByBarcode(barcode);
		}

		private void BarcodeTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == System.Windows.Input.Key.Enter)
			{
				SearchProduct_Click(sender, e);
			}
		}

		private void LoadProductByBarcode(string barcode)
		{
			string query = "SELECT Name, SKU, Quantity, UnitPrice FROM Products WHERE Barcode = @Barcode";
			var parameters = new { Barcode = barcode };

			DataTable productData = _dbHelper.ExecuteQuery(query, parameters);
			if (productData != null && productData.Rows.Count > 0)
			{
				var product = productData.Rows[0];
				ProductInfoTextBlock.Text = $"Name: {product["Name"]}\nSKU: {product["SKU"]}\nQuantity: {product["Quantity"]}\nUnit Price: {product["UnitPrice"]:C}";
			}
			else
			{
				ProductInfoTextBlock.Text = "Product not found.";
			}
		}
	}
}