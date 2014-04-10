using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Savnac.Web.Models;

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
            MessageList messages = new MessageList();

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
            //if (ModelState.IsValid)
            //{
            //    System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection("Data Source=..\\Savnac.Database\\MyDatabase#1.sdf;Password=***********;Persist Security Info=True");
            //    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            //    cmd.CommandType = System.Data.CommandType.Text;
            //    cmd.CommandText = "INSERT INTO messageTable (msg_sEmail, msg_rEmail, msg_subject, msg_content, msg_dateTime, msg_isRead ) VALUES (" + model.sender + ", " + model.recipient + ", " + model.subject + ", " + model.message + ", " + model.timeSent + ", " + model.isRead +")";
            //    cmd.Connection = sqlConnection1;

            //    sqlConnection1.Open();
            //    cmd.ExecuteNonQuery();
            //    sqlConnection1.Close();
            //}

            return RedirectToAction("SendMessage");
        }

		[Authorize]
		public ActionResult SendMessage()
		{
			return View();
		}
    }
}
