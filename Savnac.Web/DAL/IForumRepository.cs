using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Savnac.Web.Models;


namespace Savnac.Web.DAL
{
    public interface IForumRepository
    {
        IEnumerable<Forum> GetForums();
        Forum GetForumById(int forumId);
        void CreateForum(Forum forum);
        void DeleteForum(int forumId);
        void UpdateForum(Forum forum);
    }

}