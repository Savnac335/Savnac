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
    public class PostController : Controller
    {
        //
        // GET: /Post/
        [HttpPost]
        public ActionResult Create(Post newPost)
        {
            return PartialView(newPost);
        }

        public ActionResult Add(Post newPost)
        {
            return RedirectToAction("ViewThreadDetail", "Thread", new { id = newPost.ThreadID });
        }

    }
}
