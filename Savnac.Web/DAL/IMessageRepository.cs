using Savnac.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savnac.Web.DAL
{
	public interface IMessageRepository
	{
		MessageModel GetBy(int id);
		ICollection<MessageModel> GetBy(string username);

		void MarkRead(int id);

		void AddMessage(string sender, string recipient, string subject, string message);
	}
}
