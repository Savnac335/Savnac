using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Savnac.Web.Models;
using System.Data.SqlClient;
using System.Data;
using WebMatrix.WebData;
using System.Web.Security;
using Savnac.Web.Data.Composers;

namespace Savnac.Web.Controllers
{
    public class CourseController : Controller
    {
 
        [AllowAnonymous]
        public ActionResult SearchForCourse()
        {
            
            return RedirectToAction("Index", "Home");
        }

		[Authorize(Roles="Administrator")]
        [HttpGet]
        public ViewResult addCourseForm()
        {
            return View();
        }

		[Authorize(Roles = "Administrator")]
        [HttpPost]
        public ViewResult addCourseForm(Course courseAdded)
        {
            CourseComposer composer = new CourseComposer();
            composer.AddCourse(courseAdded.CourseName, courseAdded.TeacherName, courseAdded.Syllabus, courseAdded.AnnouncementId);

            return View("courseAdded", courseAdded);
        }

		[HttpGet]
        public ActionResult StudentCoursePage(int id)
        {
            CourseRetriever retriever = new CourseRetriever();
            Course course = retriever.StudentGetBy(id);

			if(course != null)
				return View(course);	
			else
				return RedirectToAction("Index", "Home");
        }

		[HttpGet]
		public ActionResult TeacherCoursePage(int id)
		{
            CourseRetriever retriever = new CourseRetriever();
            Course course = retriever.TeacherGetBy(id);

			if (course != null)
				return View(course);
			else
				return RedirectToAction("Index", "Home");
		}

        public ActionResult Gradebook()
        {
            CourseList classes = new CourseList();
            
            return View(classes);
        }
    }
}
