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
    public class AssignmentScore
    {
        int grade { get; set; }
        public HttpPostedFileBase submission { get; set; }
    }

    public class Atendee
    {
        public int AtendeeId { get; set; }
        public string AtendeeName { get; set; }
        public int CourseId { get; set; }
        public bool isTeacher { get; set;}
    }

    public class Listings
    {
        public int courseId { get; set; }
        public string courseName { get; set; }
        public int atendeeId { get; set; }
        public string atendeeName { get; set; }
    }

    public class Assignment
    {
        public string AssignmentName { get; set; }
        public string AssignmentDesc { get; set; }
		public int grade { get; set; }
        public DateTime dateDue { get; set; }
        public ICollection<AssignmentScore> scores;
    }

    [Table("Course")]
    public class Course
    {
        [Required(ErrorMessage = "Please enter the course name") ]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Please enter the course's ID")]
        public int CourseId { get; set; }
        public string Syllabus { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
		public int grade 
        { 
			get
			{ 
				int g = 0;

				if (Assignments.Count == 0) return 0;

				foreach (Assignment i in Assignments)
					g += i.grade; 
				
				return g / Assignments.Count;
			}
		}

		public int AnnouncementId { get; set; }
		public AnnouncementModel Announcement { get; set; }

		public Course()
		{
			Assignments = new List<Assignment>();
			Announcement = new AnnouncementModel();
		}
    }

    public class CourseList
    {
        public List<Course> Courses { get; set; }
    }
        
}