using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Inventory_Management_System
{
	public partial class DashboardPage : Window
	{
		private DatabaseHelper dbHelper = new DatabaseHelper();

		public DashboardPage()
		{
			InitializeComponent();
		}

		private void LoadProducts_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			string query = "SELECT Id, Name, Quantity FROM Products";
			DataTable dt = dbHelper.ExecuteQuery(query);
			ProductsListView.ItemsSource = dt.DefaultView;
		}
	}
}