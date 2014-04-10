using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Savnac.Web.Models;

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
		public ActionResult ComposeAnnouncement()
		{
			return View();
		}

		[HttpPost]
		public ActionResult ComposeAnnouncement(AnnouncementModel model)
		{
			//TODO: Add message to database

			return RedirectToAction("SendAnnouncement");
		}

		[Authorize]
		public ActionResult SendAnnouncement()
		{
			return View();
		}
    }
}
