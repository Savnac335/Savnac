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
			MessageRepository repository = new MessageRepository();
			ICollection<MessageModel> messages = repository.GetBy(User.Identity.Name);

			return View(messages);
		}

		[Authorize]
		public ActionResult ReadMessage(MessageModel model)
		{
			MessageRepository repository = new MessageRepository();
			repository.MarkRead(model.id);

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
			MessageRepository repository = new MessageRepository();
			repository.AddMessage(User.Identity.Name, model.recipient, model.subject, model.message);

            return RedirectToAction("SendMessage");
        }

		[Authorize]
		public ActionResult SendMessage()
		{
			return View();
		}
    }
}
