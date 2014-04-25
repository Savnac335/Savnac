using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Savnac.Web.Models;
using System.Data.SqlClient;
using System.Data;
using Savnac.Web.DAL;

namespace Savnac.Web.Controllers
{
    public class AttendanceController : Controller
    {
        //
        // GET: /Attendance/

        [HttpGet]
        public ActionResult CourseAttendance()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CourseAttendance(CourseAttendanceModel model)
        {
            if (ModelState.IsValid)
            {
                AttendanceRepository attendance = new AttendanceRepository();
                attendance.OnSave(model.studentName, model.isPresent, model.currentDate);

                return View("SaveAttendance", model);
            }
            else
            {
                return View();
            }
        }
    }
}