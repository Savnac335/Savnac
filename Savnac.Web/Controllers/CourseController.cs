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
            if (ModelState.IsValid)
            {
				var sql = string.Format("INSERT INTO Course (courseName, teacherName, syllabusName, announcementId) VALUES ('{0}', '{1}', '{2}', '{3}')", courseAdded.CourseName, courseAdded.TeacherName, "", -1);
				var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

				var command = new SqlCommand(sql, new SqlConnection(connectionString));

				using (var connection = command.Connection)
				{
					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}

                return View("courseAdded", courseAdded);
            }
            else
            {
                return View();
            }
        }

		[HttpGet]
        public ActionResult StudentCoursePage(int id)
        {
			Course course;

			var sql = string.Format("SELECT * FROM Course WHERE courseId = '{0}'", id);
			var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

			var command = new SqlCommand(sql, new SqlConnection(connectionString));

			using (var connection = command.Connection)
			{
				connection.Open();

				using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
				{
					reader.Read();

					course = new Course()
					{
						CourseId = id,
						CourseName = reader["courseName"].ToString(),
						TeacherName = reader["teacherName"].ToString(),
						Syllabus = reader["syllabusName"].ToString(),
						AnnouncementId = (int)reader["announcementId"]
					};
				}

				connection.Close();
			}

			if (course.AnnouncementId != -1)
			{
				sql = string.Format("SELECT * FROM Announcement WHERE announcementId = '{0}'", course.AnnouncementId);
				command = new SqlCommand(sql, new SqlConnection(connectionString));

				using (var connection = command.Connection)
				{
					connection.Open();

					using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
					{
						reader.Read();

						course.Announcement = new AnnouncementModel()
						{
							user = reader["username"].ToString(),
							title = reader["title"].ToString(),
							body = reader["body"].ToString(),
							timePosted = (DateTime)reader["timePosted"],
							classId = id
						};
					}

					connection.Close();
				}
			}
			else
			{
				course.Announcement = new AnnouncementModel();
			}

			if(course != null)
				return View(course);	
			else
				return RedirectToAction("Index", "Home");
        }

		[HttpGet]
		public ActionResult TeacherCoursePage(int id)
		{
			Course course;

			var sql = string.Format("SELECT * FROM Course WHERE courseId = '{0}'", id);
			var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

			var command = new SqlCommand(sql, new SqlConnection(connectionString));

			using (var connection = command.Connection)
			{
				connection.Open();

				using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
				{
					reader.Read();

					course = new Course()
					{
						CourseId = id,
						CourseName = reader["courseName"].ToString(),
						TeacherName = reader["teacherName"].ToString(),
						Syllabus = reader["syllabusName"].ToString(),
						AnnouncementId = (int)reader["announcementId"]
					};
				}

				connection.Close();
			}

			if (course.AnnouncementId != -1)
			{
				sql = string.Format("SELECT * FROM Announcement WHERE announcementId = '{0}'", course.AnnouncementId);
				command = new SqlCommand(sql, new SqlConnection(connectionString));

				using (var connection = command.Connection)
				{
					connection.Open();

					using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
					{
						reader.Read();

						course.Announcement = new AnnouncementModel()
						{
							user = reader["username"].ToString(),
							title = reader["title"].ToString(),
							body = reader["body"].ToString(),
							timePosted = (DateTime)reader["timePosted"],
							classId = id
						};
					}

					connection.Close();
				}
			}
			else
			{
				course.Announcement = new AnnouncementModel();
			}

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
