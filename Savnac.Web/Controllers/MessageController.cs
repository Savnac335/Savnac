using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Savnac.Web.Models;
using System.Data.SqlClient;
using System.Data;
using Savnac.Web.Data;

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
			MessageModelRetriever retriever = new MessageModelRetriever();
			ICollection<MessageModel> messages = retriever.GetBy(User.Identity.Name);

			return View(messages);
		}

		[Authorize]
		public ActionResult ReadMessage(MessageModel model)
		{
			MessageModelUpdater updater = new MessageModelUpdater();
			updater.MarkRead(model.id);

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
			MessageModelComposer composer = new MessageModelComposer();
			composer.AddMessage(User.Identity.Name, model.recipient, model.subject, model.message);

            return RedirectToAction("SendMessage");
        }

		[Authorize]
		public ActionResult SendMessage()
		{
			return View();
		}
    }
}
