using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Savnac.Web.Models;

namespace Savnac.Web.Controllers
{
    public class ClassController : Controller
    {
 
        [AllowAnonymous]
        public ActionResult SearchForClass()
        {
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult addClassForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult addClassForm(Class classAdded)
        {
            if (ModelState.IsValid)
            {
                return View("classAdded", classAdded);
            }
            else
            {
                return View();
            }
        }

    }
}
