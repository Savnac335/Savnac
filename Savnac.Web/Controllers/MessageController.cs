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
    }
}
