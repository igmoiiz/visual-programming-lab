using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Inventory_Management_System
{
	public partial class CustomerManagement : Window
	{
		private DatabaseHelper _dbHelper;

		public CustomerManagement()
		{
			InitializeComponent();
			_dbHelper = new DatabaseHelper();
			LoadCustomers();
		}

		private void LoadCustomers()
		{
			string query = "SELECT * FROM Customers"; // Assuming you have a Customers table
			DataTable customers = _dbHelper.ExecuteQuery(query);
			if (customers != null)
			{
				CustomerDataGrid.ItemsSource = customers.DefaultView;
			}
		}

		private void AddCustomer_Click(object sender, RoutedEventArgs e)
		{
			string query = "INSERT INTO Customers (CustomerName, ContactName, Phone, Email, Address) VALUES (@CustomerName, @ContactName , @Phone, @Email, @Address)";
			var parameters = new
			{
				CustomerName = CustomerNameTextBox.Text,
				ContactName = ContactNameTextBox.Text,
				Phone = PhoneTextBox.Text,
				Email = EmailTextBox.Text,
				Address = AddressTextBox.Text
			};

			_dbHelper.ExecuteNonQuery(query, parameters);
			StatusTextBlock.Text = "Customer added successfully!";
			LoadCustomers();
			ClearFields();
		}

		private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
		{
			if (CustomerDataGrid.SelectedItem == null)
			{
				MessageBox.Show("Please select a customer to update.");
				return;
			}

			DataRowView selectedRow = (DataRowView)CustomerDataGrid.SelectedItem;
			int customerId = (int)selectedRow["CustomerID"]; // Assuming CustomerID is the primary key

			string query = "UPDATE Customers SET CustomerName = @CustomerName, ContactName = @ContactName, Phone = @Phone, Email = @Email, Address = @Address WHERE CustomerID = @CustomerID";
			var parameters = new
			{
				CustomerID = customerId,
				CustomerName = CustomerNameTextBox.Text,
				ContactName = ContactNameTextBox.Text,
				Phone = PhoneTextBox.Text,
				Email = EmailTextBox.Text,
				Address = AddressTextBox.Text
			};

			_dbHelper.ExecuteNonQuery(query, parameters);
			StatusTextBlock.Text = "Customer updated successfully!";
			LoadCustomers();
			ClearFields();
		}

		private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
		{
			if (CustomerDataGrid.SelectedItem == null)
			{
				MessageBox.Show("Please select a customer to delete.");
				return;
			}

			DataRowView selectedRow = (DataRowView)CustomerDataGrid.SelectedItem;
			int customerId = (int)selectedRow["CustomerID"]; // Assuming CustomerID is the primary key

			string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
			var parameters = new { CustomerID = customerId };

			_dbHelper.ExecuteNonQuery(query, parameters);
			StatusTextBlock.Text = "Customer deleted successfully!";
			LoadCustomers();
		}

		private void ClearFields()
		{
			CustomerNameTextBox.Clear();
			ContactNameTextBox.Clear();
			PhoneTextBox.Clear();
			EmailTextBox.Clear();
			AddressTextBox.Clear();
		}
	}
}