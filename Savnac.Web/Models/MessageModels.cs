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
		public string sender { get; set; }
		public string receiver { get; set; }

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

	public class MessageList
	{
		public List<MessageModel> Messages { get; set; }

		public MessageList()
		{
			Messages = new List<MessageModel>()
			{
				new MessageModel() {sender = "eric.pacelli", receiver = "james.peck", subject = "hi", message = "bye james"},
				new MessageModel() {sender = "james.peck", receiver = "eric.pacelli", subject = "bye", message = "you suck"}
			};
		}
	}
}