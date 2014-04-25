using Savnac.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savnac.Web.DAL
{
	interface ICourseRepository
	{
		void AddCourse(string courseName, int courseId, string syllabusName, int announcementId);
		void AddPersonToCourse(string Name, int atendeeID, int courseID, bool isTeacher);

		ICollection<Listings> getClassListings();
		ICollection<Listings> getClassAtendeeListings(int classId);
		Course GetBy(int id);
	}
}
