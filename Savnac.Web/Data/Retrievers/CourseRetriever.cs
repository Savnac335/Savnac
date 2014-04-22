using Savnac.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Savnac.Web.Data.Composers
{
    public class CourseRetriever
    {
        public Course StudentGetBy(int id)
        {
            Course course;

            var sql = string.Format("SELECT * FROM Course WHERE courseId = '{0}'", id);
            var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

            var command = new SqlCommand(sql, new SqlConnection(connectionString));

            using (var connection = command.Connection)
            {
                connection.Open();

                using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
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

                    using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
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
            return course;
        }

        public Course TeacherGetBy(int id)
        {
            Course course;

            var sql = string.Format("SELECT * FROM Course WHERE courseId = '{0}'", id);
            var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

            var command = new SqlCommand(sql, new SqlConnection(connectionString));

            using (var connection = command.Connection)
            {
                connection.Open();

                using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
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

                    using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
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

            return course;
        }
    }
}