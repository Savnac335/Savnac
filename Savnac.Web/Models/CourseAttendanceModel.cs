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
        public string studentName { get; set; }
        public bool isPresent { get; set; }
        [DataType(DataType.Date)]
        public DateTime currentDate { get; set; }
    }
}