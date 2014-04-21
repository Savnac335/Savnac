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
    public class AnnouncementController : Controller
    {
		public ActionResult Index()
		{
			//return View();
			return RedirectToAction("addClassForm", "Class");
		}

		[Authorize]
		[HttpGet]
		public ActionResult ComposeAnnouncement(int courseId)
		{
			return View();
		}

		[HttpPost]
		public ActionResult ComposeAnnouncement(AnnouncementModel model)
		{
			if (ModelState.IsValid)
			{
				var sql = string.Format("INSERT INTO Announcement (username, title, body, timePosted) VALUES ('{0}', '{1}', '{2}', '{3}'", User.Identity.Name, model.title, model.body, DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"));
				var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

				var command = new SqlCommand(sql, new SqlConnection(connectionString));

				using (var connection = command.Connection)
				{
					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}

			return RedirectToAction("SendAnnouncement");
		}

		[Authorize]
		public ActionResult SendAnnouncement()
		{
			return View();
		}
    }
}
