using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Savnac.Web.Models
{
	public class MessageModel
	{
		public int id { get; set; }

		public string sender { get; set; }
		public string recipient { get; set; }

		public string subject { get; set; }
		public string message { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime timeSent { get; set; }

		public bool isRead { get; set; }

		public MessageModel()
		{
			isRead = false;
			timeSent = DateTime.Now;
		}
	}
}