using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Inventory_Management_System___Design_2
{
	public class DatabaseHelper
	{
		private string connectionString = "server=localhost;database=InventoryManagement;user=root;password=332211Asdfghjkl;";

		public DataTable ExecuteQuery(string query)
		{
			using (MySqlConnection conn = new MySqlConnection(connectionString))
			{
				MySqlCommand cmd = new MySqlCommand(query, conn);
				MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				conn.Open();
				adapter.Fill(dt);
				return dt;
			}
		}

		public void ExecuteNonQuery(string query)
		{
			using (MySqlConnection conn = new MySqlConnection(connectionString))
			{
				MySqlCommand cmd = new MySqlCommand(query, conn);
				conn.Open();
				cmd.ExecuteNonQuery();
			}
		}

	}
}