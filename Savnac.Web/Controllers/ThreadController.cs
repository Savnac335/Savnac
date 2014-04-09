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
        [AllowAnonymous]
        public ActionResult ThreadSearch()
        {
            return RedirectToAction("Index", "Home");
        }
        
        
        [HttpGet]
        public ViewResult addPostForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult addPostForm(Thread threadPosted)
        {
            if (ModelState.IsValid)
            {
                return View("threadPosted", threadPosted);
            }
            else
            {
                return View();
            }
        }
    }

}
