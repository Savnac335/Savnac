using Savnac.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Savnac.Web.DAL
{
	public class MessageRepository : IMessageRepository
	{
		public MessageModel GetBy(int id)
		{
			MessageModel message = new MessageModel();

			var sql = string.Format("SELECT * FROM Message WHERE msg_id = '{0}'", id);
			var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

			var command = new SqlCommand(sql, new SqlConnection(connectionString));

			using (var connection = command.Connection)
			{
				connection.Open();

				using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
				{
					message = new MessageModel()
					{
						id = (int)reader["msg_id"],
						sender = reader["msg_sEmail"].ToString(),
						recipient = reader["msg_rEmail"].ToString(),
						subject = reader["msg_subject"].ToString(),
						message = reader["msg_content"].ToString(),
						timeSent = (DateTime)reader["msg_dateTime"],
						isRead = (bool)reader["msg_isRead"]
					};
				}
			}

			return message;
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