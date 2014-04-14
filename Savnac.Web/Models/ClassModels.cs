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
    public class Assignment
    {
        public string AssignmentName { get; set; }
        public string AssignmentDesc { get; set; }
        public int grade { get; set; }
    }

    [Table("Class")]
    public class Class
    {
        [Required(ErrorMessage = "Please enter the class name") ]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "Please enter the teacher's name")]
        public string TeacherName { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
		public int grade { get { int g = 0; foreach (Assignment i in Assignments) g += i.grade; return g / Assignments.Count; } }

		public int AnnouncementId { get; set; }
		public AnnouncementModel Announcement { get; set; }
    }

    public class ClassList
    {
        public List<Class> Classes { get; set; }

        public ClassList()
		{
            Classes = new List<Class>()
			{
				new Class() {ClassName = "SUPER SWEET TEST CLASS", TeacherName = "SUPER COOL TEST TEACHER", Assignments = new List<Assignment> {new Assignment() {AssignmentName = "Project thing", AssignmentDesc = "This assignment is amazing and stuff", grade = 86}, new Assignment() {AssignmentName = "Attendance", AssignmentDesc = "No description set", grade = 100}}},
                new Class() {ClassName = "kinda meh test class", TeacherName = "not-so-great test teacher", Assignments = new List<Assignment> {new Assignment() {AssignmentName = "Giant Paper", AssignmentDesc = "Yup that's right 100-page minimum or something", grade = 73}, new Assignment() {AssignmentName = "Smaller Paper", AssignmentDesc = "This one's only a couple of pages long", grade = 94}}}
			};
		}
    }
}