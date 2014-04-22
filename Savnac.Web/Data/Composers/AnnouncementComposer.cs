using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Savnac.Web.Data
{
	public class AnnouncementComposer
	{
		public void AddAnnouncement(string username, string title, string message)
		{
			var sql = string.Format("INSERT INTO Announcement (username, title, body, timePosted) VALUES ('{0}', '{1}', '{2}', '{3}'", username, title, message, DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"));
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