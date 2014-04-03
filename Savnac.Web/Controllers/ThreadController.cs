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
using Savnac.Web.Filters;
using Savnac.Web.Models;

namespace Savnac.Web.Controllers
{
    public class ThreadController : Controller
    {
        //
        // GET: /Thread/

        public class ThreadDetialViewModel
        {
            public Thread Thread { get; set; }
            public Post NewPost { get; set; }
        }

        public ActionResult ViewThreadDetail(int id)
        {
            var thread = new Thread() { ThreadID = id, ThreadTitle = "Savnac", Posts = new List<Post>() };
            var newPost = new Post() { PostTitle = "", PostText = "", ThreadID = id };

            return View(new ThreadDetialViewModel() { Thread = thread, NewPost = newPost });
        }

    }
}
