using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Savnac.Web.Data.Composers
{
    public class CourseComposer
    {
        public void AddCourse(string courseName, string teacherName, string syllabusName, int announcementId)
        {
            var sql = string.Format("INSERT INTO Course (courseName, teacherName, syllabusName, announcementId) VALUES ('{0}', '{1}', '{2}', '{3}')", courseName, teacherName, "", -1);
            var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

            var command = new SqlCommand(sql, new SqlConnection(connectionString));

            using (var connection = command.Connection)
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}