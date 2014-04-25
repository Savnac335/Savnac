using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savnac.Web.DAL
{
	public interface IAnnouncementRepository
	{
		void AddAnnouncement(string username, string title, string message);
	}
}
