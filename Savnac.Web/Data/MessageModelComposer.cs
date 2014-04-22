using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Savnac.Web.Data
{
	public class MessageModelComposer
	{
		public void AddMessage(string sender, string recipient, string subject, string message)
		{
			var sql = string.Format("INSERT INTO Message (msg_sEmail, msg_rEmail, msg_subject, msg_content, msg_dateTime, msg_isRead) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", sender, recipient, subject, message, DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"), false);
			var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

			var command = new SqlCommand(sql, new SqlConnection(connectionString));

			using (var connection = command.Connection)
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
		}
	}
}