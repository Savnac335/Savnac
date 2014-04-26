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
    public class ForumController : Controller
    {
        //private IForumRepository forumRepository;

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Forum()
        {
            ForumRepository repository = new ForumRepository();
            ICollection<ForumModel> posts = repository.GetForumBy(User.Identity.Name);

            return View(posts);
        }

        [Authorize]
        public ActionResult ReadPost(ForumModel model)
        {
            ForumRepository repository = new ForumRepository();
            repository.MarkRead(model.postId);

            return View(model);
        }

        [Authorize]
        public ActionResult ComposePost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ComposePost(ForumModel model)
        {
            ForumRepository repository = new ForumRepository();
            repository.AddPost(User.Identity.Name, model.title, model.content, model.courseId);

            return RedirectToAction("PostMessage");
        }

        [Authorize]
        public ActionResult PostMessage()
        {
            return View();
        }

    }
}