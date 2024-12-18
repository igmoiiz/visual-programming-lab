using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Inventory_Management_System___Design_2
{
	public class DatabaseHelper
	{
		public string ConnectionString = "server=localhost;database=InventoryManagement;user=root;password=332211Asdfghjkl;";

		// Method to execute a query that returns a DataTable
		public DataTable ExecuteQuery(string query)
		{
			using (MySqlConnection conn = new MySqlConnection(ConnectionString))
			{
				MySqlCommand cmd = new MySqlCommand(query, conn);
				MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				conn.Open();
				adapter.Fill(dt);
				return dt;
			}
		}

		// Method to execute a non-query command (INSERT, UPDATE, DELETE)
		public void ExecuteNonQuery(string query)
		{
			using (MySqlConnection conn = new MySqlConnection(ConnectionString))
			{
				MySqlCommand cmd = new MySqlCommand(query, conn);
				conn.Open();
				cmd.ExecuteNonQuery();
			}
		}

		// Method to execute a scalar command (SELECT COUNT, etc.)
		public object ExecuteScalar(string query)
		{
			using (MySqlConnection conn = new MySqlConnection(ConnectionString))
			{
				MySqlCommand cmd = new MySqlCommand(query, conn);
				conn.Open();
				return cmd.ExecuteScalar(); // Returns the first column of the first row in the result set
			}
		}
	}
}