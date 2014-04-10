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

	public class MessageList
	{
		public List<MessageModel> Messages { get; set; }

		public MessageList()
		{
			Messages = new List<MessageModel>()
			{
				new MessageModel() {sender = "eric.pacelli", recipient = "james.peck", subject = "hi", message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent leo sapien, rutrum a erat ac, vestibulum tempor ipsum. Pellentesque consequat quis dolor nec semper. Interdum et malesuada fames ac ante ipsum primis in faucibus. Curabitur tellus est, elementum at urna et, mollis hendrerit massa. Sed porttitor justo sit amet orci dictum porta. Morbi et nulla rhoncus, posuere enim sed, faucibus magna. Aliquam dapibus luctus lacus. Morbi non pellentesque turpis, non scelerisque ipsum. Fusce sit amet justo pulvinar, dictum urna a, pharetra dui. Quisque tempus nisl sit amet sagittis rhoncus. Quisque rutrum sed velit a hendrerit. Ut sed adipiscing ipsum, venenatis scelerisque nibh. Phasellus et consectetur arcu, ut sollicitudin eros. Phasellus id leo cursus, rhoncus magna id, consequat nunc. Praesent lorem purus, consectetur sed lorem et, dapibus dignissim turpis. Nullam volutpat eros ut ornare sagittis. Nullam fringilla gravida augue nec faucibus. Etiam molestie ipsum felis, ut consectetur tellus sagittis in. Nullam blandit ornare sem, vel mattis mi suscipit nec. Nam fringilla, elit dictum sagittis dapibus, ante elit dignissim lacus, sit amet luctus odio quam vitae risus. In hac habitasse platea dictumst. Mauris lobortis nulla arcu, eu varius enim fermentum eget. Duis lacinia quis nibh sit amet molestie. Duis fringilla pharetra vulputate."},
				new MessageModel() {sender = "james.peck", recipient = "eric.pacelli", subject = "bye", message = "you suck"},
                new MessageModel() {sender = "james.peck", recipient = "eric.pacelli", subject = "dshfgsddfffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffjhf", message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent leo sapien, rutrum a erat ac, vestibulum"},
                new MessageModel() {sender = "james.peck", recipient = "eric.pacelli", subject = "Lorem Praesent leo sapien", message = "Lorem Praesent leo sapien, rutrum a erat ac, vestibulum"},
                new MessageModel() {sender = "Druk", recipient = "godsfist10", subject = "Kuzu-zangpola Paul", message = "Charo choe layshom bay wong noi ray wa yoe. Tashi Delek!"},
			};
		}
	}
}