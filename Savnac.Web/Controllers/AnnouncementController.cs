using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Savnac.Web.Models;
using System.Data.SqlClient;
using System.Data;
using Savnac.Web.DAL;

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
			AnnouncementRepository repository = new AnnouncementRepository();
			repository.AddAnnouncement(User.Identity.Name, model.title, model.body);

			return RedirectToAction("SendAnnouncement");
		}

		[Authorize]
		public ActionResult SendAnnouncement()
		{
			return View();
		}
    }
}
