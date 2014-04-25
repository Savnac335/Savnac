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
using Savnac.Web.DAL;

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
			CourseRepository repository = new CourseRepository();
			repository.AddCourse(courseAdded.CourseName, courseAdded.CourseId, courseAdded.Syllabus, courseAdded.AnnouncementId);

            return View("courseAdded", courseAdded);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ViewResult addAttendeeForm()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ViewResult addAttendeeForm(Atendee atendeeAdded)
        {
			CourseRepository repository = new CourseRepository();
			repository.AddPersonToCourse(atendeeAdded.AtendeeName, atendeeAdded.AtendeeId, atendeeAdded.CourseId, atendeeAdded.isTeacher);

            return View("atendeeAdded", atendeeAdded);
        }

        [HttpGet]
        public ActionResult CourseListing()
        {
			CourseRepository repository = new CourseRepository();
			ICollection<Listings> listings = repository.getClassListings();

            if (listings != null)
                return View(listings);
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult AttendeeListing(int classID)
        {
			CourseRepository repository = new CourseRepository();
			ICollection<Listings> listings = repository.getClassAtendeeListings(classID);

            if (listings != null)
                return View(listings);
            else
                return RedirectToAction("Index", "Home");
        }

		[HttpGet]
        public ActionResult StudentCoursePage(int id)
        {
			CourseRepository repository = new CourseRepository();
			Course course = repository.GetBy(id);

			if(course != null)
				return View(course);	
			else
				return RedirectToAction("Index", "Home");
        }

		[HttpGet]
		public ActionResult TeacherCoursePage(int id)
		{
			CourseRepository repository = new CourseRepository();
			Course course = repository.GetBy(id);

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
