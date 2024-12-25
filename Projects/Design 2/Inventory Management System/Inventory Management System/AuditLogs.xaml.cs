using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Inventory_Management_System
{
	public partial class AuditLogs : Window
	{
		private DatabaseHelper _dbHelper;

		public AuditLogs()
		{
			InitializeComponent();
			_dbHelper = new DatabaseHelper();
			LoadAuditLogs();
		}

		private void LoadAuditLogs()
		{
			string query = "SELECT UserID, Action, TableAffected, ActionTime, Description FROM AuditLogs ORDER BY ActionTime DESC";
			DataTable auditLogs = _dbHelper.ExecuteQuery(query);
			if (auditLogs != null)
			{
				AuditLogDataGrid.ItemsSource = auditLogs.DefaultView;
			}
			else
			{
				StatusTextBlock.Text = "No audit logs found.";
			}
		}
	}
}