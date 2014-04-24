using Savnac.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Savnac.Web.Data
{
	public class MessageModelRetriever
	{
		public IEnumerable<MessageModel> GetBy(int id)
		{
			return null;
		}

		public ICollection<MessageModel> GetBy(string username)
		{
			ICollection<MessageModel> messages = new List<MessageModel>();

			var sql = string.Format("SELECT * FROM Message WHERE msg_rEmail = '{0}' ORDER BY msg_dateTime DESC", username);
			var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

			var command = new SqlCommand(sql, new SqlConnection(connectionString));

			using (var connection = command.Connection)
			{
				connection.Open();

				using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
				{
					while (reader.Read())
					{
						messages.Add(new MessageModel()
						{
							id = (int)reader["msg_id"],
							sender = reader["msg_sEmail"].ToString(),
							recipient = reader["msg_rEmail"].ToString(),
							subject = reader["msg_subject"].ToString(),
							message = reader["msg_content"].ToString(),
							timeSent = (DateTime)reader["msg_dateTime"],
							isRead = (bool)reader["msg_isRead"]
						});
					}
				}
			}

			return messages;
		}
	}
}