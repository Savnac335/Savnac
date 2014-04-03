using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Savnac.Web.Models
{

    [Table("Class")]
    public class Class
    {
        [Required(ErrorMessage = "Please enter the class name") ]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "Please enter the teacher's name")]
        public string TeacherName { get; set; }

    }
}