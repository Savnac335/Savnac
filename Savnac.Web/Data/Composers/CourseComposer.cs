using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Savnac.Web.Data.Composers
{
    public class CourseComposer
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
    }
}