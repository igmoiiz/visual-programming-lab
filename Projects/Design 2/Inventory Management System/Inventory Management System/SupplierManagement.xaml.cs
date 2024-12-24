using System;
using System.Data;
using System.Windows;

namespace Inventory_Management_System
{
    public partial class SupplierManagement : Window
    {
        private DatabaseHelper dbHelper;

        public SupplierManagement()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            string query = "SELECT * FROM Suppliers";
            DataTable suppliers = dbHelper.ExecuteQuery(query);
            if (suppliers != null)
            {
                dataGridSuppliers.ItemsSource = suppliers.DefaultView;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string supplierName = txtSupplierName.Text;
            string contactName = txtContactName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string address = ""; // You can add a TextBox for Address if needed

            string query = $"INSERT INTO Suppliers (SupplierName, ContactName, Phone, Email, Address) VALUES ('{supplierName}', '{contactName}', '{phone}', '{email}', '{address}')";
            dbHelper.ExecuteNonQuery(query);
            LoadSuppliers(); // Refresh the DataGrid
            ClearInputs(); // Clear input fields after adding
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridSuppliers.SelectedItem is DataRowView selectedRow)
            {
                int supplierId = Convert.ToInt32(selectedRow["SupplierID"]);
                string supplierName = txtSupplierName.Text;
                string contactName = txtContactName.Text;
                string phone = txtPhone.Text;
                string email = txtEmail.Text;
                string address = ""; // You can add a TextBox for Address if needed

                string query = $"UPDATE Suppliers SET SupplierName = '{supplierName}', ContactName = '{contactName}', Phone = '{phone}', Email = '{email}', Address = '{address}' WHERE SupplierID = {supplierId}";
                dbHelper.ExecuteNonQuery(query);
                LoadSuppliers(); // Refresh the DataGrid
                ClearInputs(); // Clear input fields after updating
            }
            else
            {
                MessageBox.Show("Please select a supplier to update.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridSuppliers.SelectedItem is DataRowView selectedRow)
            {
                int supplierId = Convert.ToInt32(selectedRow["SupplierID"]);
                string query = $"DELETE FROM Suppliers WHERE SupplierID = {supplierId}";
                dbHelper.ExecuteNonQuery(query);
                LoadSuppliers(); // Refresh the DataGrid
            }
            else
            {
                MessageBox.Show("Please select a supplier to delete.");
            }
        }

        private void ClearInputs()
        {
            txtSupplierName.Clear();
            txtContactName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            // Clear address field if added
        }
    }
}