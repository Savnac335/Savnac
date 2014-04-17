using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Savnac.Web.Models
{
	public class AnnouncementModel
	{
		public string user { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime timePosted { get; set; }

		public string title { get; set; }
		public string body { get; set; }

		public int classId { get; set; }

		public AnnouncementModel()
		{
			user = "Bill Wixon";
			timePosted = DateTime.Now;
			title = "Test Announcement";
			body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eu massa ut nulla sollicitudin molestie sed nec ante. Quisque vitae scelerisque est. Quisque sagittis bibendum gravida. In mollis nunc sed consectetur molestie. Aliquam fringilla justo sem, sit amet tristique turpis pulvinar in. Nulla viverra nunc sit amet nunc placerat, eu vehicula ligula consectetur. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aenean luctus blandit massa et consectetur.";
			classId = -1;
		}
	}
}