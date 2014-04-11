using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Savnac.Web.Models;
using System.Data.SqlClient;
using System.Data;

namespace Savnac.Web.Controllers
{
    public class MessageController : Controller
    {
        //
        // GET: /Message/

        public ActionResult Index()
        {
            return View();
        }

		//
		// GET: /Message/Inbox/

		[Authorize]
		public ActionResult Inbox()
		{
            List<MessageModel> messages = new List<MessageModel>();

			var sql = string.Format("SELECT * FROM messageTable WHERE msg_rEmail = '{0}' ORDER BY msg_dateTime DESC", User.Identity.Name);
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

			return View(messages);
		}

		[Authorize]
		public ActionResult ReadMessage(MessageModel model)
		{
			return View(model);
		}

		[Authorize]
		public ActionResult ComposeMessage()
		{
			return View();
		}

        [HttpPost]
        public ActionResult ComposeMessage(MessageModel model)
        {
			if (ModelState.IsValid)
			{
				var sql = string.Format("INSERT INTO messageTable (msg_sEmail, msg_rEmail, msg_subject, msg_content, msg_dateTime, msg_isRead) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", User.Identity.Name, model.recipient, model.subject, model.message, DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"), false);
				var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

				var command = new SqlCommand(sql, new SqlConnection(connectionString));

				using (var connection = command.Connection)
				{
					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}

				/*System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection("Data Source=..\\Savnac.Database\\MyDatabase#1.sdf;Password=***********;Persist Security Info=True");
				System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.CommandText = "INSERT INTO messageTable (msg_sEmail, msg_rEmail, msg_subject, msg_content, msg_dateTime, msg_isRead ) VALUES (" + model.sender + ", " + model.recipient + ", " + model.subject + ", " + model.message + ", " + model.timeSent + ", " + model.isRead + ")";
				cmd.Connection = sqlConnection1;

				sqlConnection1.Open();
				cmd.ExecuteNonQuery();
				sqlConnection1.Close();*/
			}

            return RedirectToAction("SendMessage");
        }

		[Authorize]
		public ActionResult SendMessage()
		{
			return View();
		}
    }
}
