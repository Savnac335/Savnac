using Savnac.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Savnac.Web.DAL
{
	public class CourseRepository
	{
		public void AddCourse(string courseName, int courseId, string syllabusName, int announcementId)
		{
			var sql = string.Format("INSERT INTO Course (courseId, courseName, syllabusName, announcementId) VALUES ('{0}', '{1}', '{2}', '{3}')", courseId, courseName, "", -1);
			var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

			var command = new SqlCommand(sql, new SqlConnection(connectionString));

			using (var connection = command.Connection)
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		public void AddPersonToCourse(string Name, int atendeeID, int courseID, bool isTeacher)
		{
			var sql = string.Format("INSERT INTO Atendee (AtendeeId, AtendeeName, CourseId, isTeacher) VALUES ('{0}', '{1}', '{2}', '{3}')", atendeeID, Name, courseID, isTeacher);

			var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

			var command = new SqlCommand(sql, new SqlConnection(connectionString));

			using (var connection = command.Connection)
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}

			sql = string.Format("INSERT INTO JoinTable (AtendeeID, CourseID) VALUES ({0}, {1})", atendeeID, courseID);

			var command2 = new SqlCommand(sql, new SqlConnection(connectionString));

			using (var connection = command.Connection)
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		public ICollection<Listings> getClassListings()
		{
			ICollection<Listings> returnListings = new List<Listings>();

			var sql = string.Format("SELECT * FROM Course ORDER BY courseName DESC");
			var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

			var command = new SqlCommand(sql, new SqlConnection(connectionString));

			using (var connection = command.Connection)
			{
				connection.Open();

				using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
				{
					while (reader.Read())
					{
						returnListings.Add(new Listings()
						{
							courseId = (int)reader["courseId"],
							courseName = reader["courseName"].ToString()
						});
					}
				}
			}

			return returnListings;
		}

		public ICollection<Listings> getClassAtendeeListings(int classId)
		{
			ICollection<Listings> returnListings = new List<Listings>();

			var sql = string.Format("SELECT * FROM Atendee WHERE courseId = '{0}' ORDER BY courseName DESC", classId);
			var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

			var command = new SqlCommand(sql, new SqlConnection(connectionString));

			using (var connection = command.Connection)
			{
				connection.Open();

				using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
				{
					while (reader.Read())
					{
						returnListings.Add(new Listings()
						{
							atendeeId = (int)reader["attendeeId"],
							atendeeName = reader["attendeeName"].ToString()
						});
					}
				}
			}

			return returnListings;
		}

		public Course GetBy(int id)
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
						Syllabus = reader["syllabusName"].ToString()
						//AnnouncementId = (int)reader["announcementId"]
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
			return course;
		}
	}
}