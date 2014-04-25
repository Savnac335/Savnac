using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Savnac.Web.DAL
{
    public class AttendanceRepository : IAttendanceRepository
    {
        public void OnSave(string studentName, bool isPresent, DateTime currentDate)
        {
            var query = string.Format("IF NOT EXISTS (SELECT * FROM dbo.Attendance WHERE studentName='{0}') INSERT INTO Attendance (studentName, isPresent, currentDate) Values ('{1}', '{2}', '{3}')", studentName, studentName, isPresent, currentDate);
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