using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace InventoryManagement
{
	public class DatabaseHelper
	{
		private string connectionString = "Server=your_server;Database=InventoryManagement;Uid=your_username;Pwd=your_password;";

		// Method to open a connection to the database
		private MySqlConnection GetConnection()
		{
			return new MySqlConnection(connectionString);
		}

		// Method to execute a non-query command (INSERT, UPDATE, DELETE)
		public void ExecuteNonQuery(string query, List<MySqlParameter> parameters = null)
		{
			using (var connection = GetConnection())
			{
				connection.Open();
				using (var command = new MySqlCommand(query, connection))
				{
					if (parameters != null)
					{
						command.Parameters.AddRange(parameters.ToArray());
					}
					command.ExecuteNonQuery();
				}
			}
		}

		// Method to execute a query and return a DataTable
		public DataTable ExecuteQuery(string query, List<MySqlParameter> parameters = null)
		{
			DataTable dataTable = new DataTable();
			using (var connection = GetConnection())
			{
				connection.Open();
				using (var command = new MySqlCommand(query, connection))
				{
					if (parameters != null)
					{
						command.Parameters.AddRange(parameters.ToArray());
					}
					using (var adapter = new MySqlDataAdapter(command))
					{
						adapter.Fill(dataTable);
					}
				}
			}
			return dataTable;
		}

		// Example method to add a product
		public void AddProduct(string name, string sku, string category, int quantity, decimal unitPrice, string barcode)
		{
			string query = "INSERT INTO Products (Name, SKU, Category, Quantity, UnitPrice, Barcode) VALUES (@Name, @SKU, @Category, @Quantity, @UnitPrice, @Barcode)";
			var parameters = new List<MySqlParameter>
			{
				new MySqlParameter("@Name", name),
				new MySqlParameter("@SKU", sku),
				new MySqlParameter("@Category", category),
				new MySqlParameter("@Quantity", quantity),
				new MySqlParameter("@UnitPrice", unitPrice),
				new MySqlParameter("@Barcode", barcode)
			};
			ExecuteNonQuery(query, parameters);
		}

		// Example method to get all products
		public DataTable GetAllProducts()
		{
			string query = "SELECT * FROM Products";
			return ExecuteQuery(query);
		}

		private void AddProductButton_Click(object sender, RoutedEventArgs e)
		{
			DatabaseHelper dbHelper = new DatabaseHelper();
			dbHelper.AddProduct("Sample Product", "SKU123", "Category1", 10, 19.99m, "1234567890123");
			MessageBox.Show("Product added successfully!");
		}

		private void LoadProductsButton_Click(object sender, RoutedEventArgs e)
		{
			DatabaseHelper dbHelper = new DatabaseHelper();
			DataTable products = dbHelper.GetAllProducts();

			// Assuming you have a DataGrid named productsDataGrid
			productsDataGrid.ItemsSource = products.DefaultView;
		}
	}
}