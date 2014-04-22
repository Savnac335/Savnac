using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Savnac.Web.Data
{
	public class MessageModelUpdater
	{
		public void MarkRead(int id)
		{
			var sql = string.Format("UPDATE Message SET msg_isRead='true' WHERE msg_id='{0}'", id);
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