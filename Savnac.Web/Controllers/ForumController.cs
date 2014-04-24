using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Savnac.Web.DAL;
using Savnac.Web.Models;

namespace Savnac.Web.Controllers
{
    public class ForumController : Controller
    {
        private IForumRepository forumRepository;

        public ForumController()
        {
            this.forumRepository = new ForumRepository(new Savnac_ForumsContext());
        }

        public ForumController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        public ViewResult Index()
        {
            var forums = forumRepository.GetForums().OrderBy(f => f.Sequence);
            return View(forums);
        }

        [HttpPost]
        public RedirectToRouteResult Delete(int forumId)
        {
            forumRepository.DeleteForum(forumId);
            return RedirectToAction("Index");
        }
    }
}