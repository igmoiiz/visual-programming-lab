using System;
using System.Data.OleDb;

class test
{
	static void Main()
	{
		string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Moaiz\\Downloads\\Northwind.mdb;User  Id=admin;Password=;";
		string queryString = "SELECT ProductID, UnitPrice, ProductName FROM Products " +
							 "WHERE UnitPrice > ? " +
							 "ORDER BY UnitPrice DESC;";
		int paramValue = 5;

		using (OleDbConnection connection = new OleDbConnection(connectionString))
		{
			using (OleDbCommand command = new OleDbCommand(queryString, connection))
			{

				command.Parameters.AddWithValue("?", paramValue);

				try
				{
					connection.Open();
					using (OleDbDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("An error occurred: " + ex.Message);
				}
			}
		}

		Console.ReadLine();
	}
}