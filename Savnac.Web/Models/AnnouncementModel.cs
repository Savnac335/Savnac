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
	}
}