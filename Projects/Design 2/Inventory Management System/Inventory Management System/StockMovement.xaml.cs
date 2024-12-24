using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Inventory_Management_System
{
	public partial class StockMovement : Window
	{
		private DatabaseHelper dbHelper = new DatabaseHelper();

		public StockMovement()
		{
			InitializeComponent();
			LoadStockMovements();
		}

		private void LoadStockMovements()
		{
			string query = "SELECT Id, ProductId, Quantity, MovementType FROM StockMovements";
			StockMovementListView.ItemsSource = dbHelper.ExecuteQuery(query).DefaultView;
		}

		private void RecordStockIn_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			RecordStockMovement("IN");
		}

		private void RecordStockOut_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			RecordStockMovement("OUT");
		}

		private void RecordStockMovement(string movementType)
		{
			int productId;
			int quantity;
			if (int.TryParse(ProductIdTextBox.Text, out productId) && int.TryParse(MovementQuantityTextBox.Text, out quantity))
			{
				string query = $"INSERT INTO StockMovements (ProductId, Quantity, MovementType) VALUES ({productId}, {quantity}, '{movementType}')";
				dbHelper.ExecuteNonQuery(query);
				LoadStockMovements();
				ProductIdTextBox.Clear();
				MovementQuantityTextBox.Clear();
			}
		}
	}
}