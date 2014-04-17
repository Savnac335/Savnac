using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Savnac.Web.Models
{
    public class CourseAttendanceModel
    {
        public List<string> professorNameList { get; set; }
        public List<string> studentNameList { get; set; }
        public bool isPresent { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }

    public class onSave
    {
        public void Save(CourseAttendanceModel model)
        {
            for (int i = 0; model.studentNameList.Count != 0; i++)
            {
                var query = string.Format("Insert Into attendanceTable (studentName, isPresent, currentDate) Values ({0}, {1}, {3})", model.studentNameList[i], model.isPresent);
                var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

                var command = new SqlCommand(query, new SqlConnection(connectionString));

                using (var connection = command.Connection)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}