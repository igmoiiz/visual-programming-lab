using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace Inventory_Management_System
{
	public class DatabaseHelper
	{
		public string ConnectionString = "server=localhost;database=InventoryManagement;user=root;password=332211Asdfghjkl;";

		public DataTable ExecuteQuery(string query, object parameters = null)
		{
			try
			{
				using (MySqlConnection conn = new MySqlConnection(ConnectionString))
				{
					MySqlCommand cmd = new MySqlCommand(query, conn);
					if (parameters != null)
					{
						// Assuming parameters is an anonymous object
						foreach (var prop in parameters.GetType().GetProperties())
						{
							cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters));
						}
					}
					MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					conn.Open();
					adapter.Fill(dt);
					return dt;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error executing query: {ex.Message}");
				return null;
			}
		}

		public void ExecuteNonQuery(string query, object parameters = null, MySqlTransaction transaction = null)
		{
			try
			{
				using (MySqlConnection conn = new MySqlConnection(ConnectionString))
				{
					MySqlCommand cmd = new MySqlCommand(query, conn);
					if (transaction != null)
					{
						cmd.Transaction = transaction;
					}
					conn.Open();
					if (parameters != null)
					{
						foreach (var prop in parameters.GetType().GetProperties())
						{
							cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters));
						}
					}
					cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error executing non-query: {ex.Message}");
			}
		}

		public object ExecuteScalar(string query, object parameters = null, MySqlTransaction transaction = null)
		{
			try
			{
				using (MySqlConnection conn = new MySqlConnection(ConnectionString))
				{
					MySqlCommand cmd = new MySqlCommand(query, conn);
					if (transaction != null)
					{
						cmd.Transaction = transaction;
					}
					conn.Open();
					if (parameters != null)
					{
						foreach (var prop in parameters.GetType().GetProperties())
						{
							cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters));
						}
					}
					return cmd.ExecuteScalar();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error executing scalar query: {ex.Message}");
				return null;
			}
		}

		public MySqlTransaction BeginTransaction()
		{
			MySqlConnection conn = new MySqlConnection(ConnectionString);
			conn.Open();
			return conn.BeginTransaction();
		}
	}
}