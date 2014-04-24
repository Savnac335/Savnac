using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Savnac.Web.DAL;
using Savnac.Web.Models;

namespace Savnac.Web.Controllers
{
    public class ThreadController : Controller
    {
        private IThreadRepository threadRepository;

        public ThreadController()
        {
            this.threadRepository = new ThreadRepository(new Savnac_ForumsContext());
        }

        public ThreadController(IThreadRepository threadRepository)
        {
            this.threadRepository = threadRepository;
        }

        public ViewResult Index(int forumId)
        {
            var threads = threadRepository.GetThreads()
                .Where(t => t.ForumId == forumId)
                .OrderByDescending(t => t.DateCreated);

            ViewBag.ForumTitle = threadRepository.GetForum(forumId).Title;

            return View(threads);
        }
    }

}
