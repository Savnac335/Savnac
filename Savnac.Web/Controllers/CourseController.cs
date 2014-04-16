using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Savnac.Web.Models;

namespace Savnac.Web.Controllers
{
    public class CourseController : Controller
    {
 
        [AllowAnonymous]
        public ActionResult SearchForCourse()
        {
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult addCourseForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult addCourseForm(Course courseAdded)
        {
            if (ModelState.IsValid)
            {
                return View("courseAdded", courseAdded);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult StudentCoursePage()
        {
            return View();
        }

        public ActionResult Gradebook()
        {
            CourseList classes = new CourseList();
            
            return View(classes);
        }
    }
}
