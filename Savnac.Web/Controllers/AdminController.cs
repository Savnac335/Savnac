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
	public class AdminController : Controller
	{
		//
		// GET: /Admin/

		[Authorize(Roles = "Administrator")]
		public ActionResult Index()
		{
			return View();
		}

	}
}
