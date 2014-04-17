using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Savnac.Web.Models;

namespace Savnac.Web.Controllers
{
    public class AttendanceController : Controller
    {
        //
        // GET: /Attendance/

        public ActionResult CourseAttendance()
        {
            return View();
        }

        [HttpGet]
        public ViewResult SaveAttendance()
        {
            return View("CourseAttendance");
        }

        [HttpPost]
        public ViewResult SaveAttendance(CourseAttendanceModel model)
        {
            ViewBag.isPresent = false;

            return View("AttendanceSaved", model);
        }
    }
}