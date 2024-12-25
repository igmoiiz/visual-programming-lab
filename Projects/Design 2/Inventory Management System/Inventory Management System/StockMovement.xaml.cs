using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Inventory_Management_System
{
	public partial class StockMovement : Window
	{
		private DatabaseHelper _dbHelper;

		public StockMovement()
		{
			InitializeComponent();
			_dbHelper = new DatabaseHelper();
			LoadProducts();
		}

		private void LoadProducts()
		{
			string query = "SELECT ProductID, Name FROM Products";
			DataTable products = _dbHelper.ExecuteQuery(query);
			if (products != null)
			{
				ProductComboBox.ItemsSource = products.DefaultView;
				ProductComboBox.DisplayMemberPath = "Name";
				ProductComboBox.SelectedValuePath = "ProductID";
			}
		}

		private void RecordMovement_Click(object sender, RoutedEventArgs e)
		{
			if (ProductComboBox.SelectedValue == null || string.IsNullOrEmpty(QuantityTextBox.Text))
			{
				MessageBox.Show("Please select a product and enter a quantity.");
				return;
			}

			int productId = (int)ProductComboBox.SelectedValue;
			string movementType = ((ComboBoxItem)MovementTypeComboBox.SelectedItem).Content.ToString();
			int quantity = int.Parse(QuantityTextBox.Text);
			string description = DescriptionTextBox.Text;

			string query = "INSERT INTO StockMovements (ProductID, MovementType, Quantity, Description) VALUES (@ProductID, @MovementType, @Quantity, @Description)";
			var parameters = new
			{
				ProductID = productId,
				MovementType = movementType,
				Quantity = quantity,
				Description = description
			};

			_dbHelper.ExecuteNonQuery(query, parameters);
			StatusTextBlock.Text = "Stock movement recorded successfully!";
			ClearFields();
		}

		private void ClearFields()
		{
			ProductComboBox.SelectedIndex = -1;
			MovementTypeComboBox.SelectedIndex = -1;
			QuantityTextBox.Clear();
			DescriptionTextBox.Clear();
		}
	}
}