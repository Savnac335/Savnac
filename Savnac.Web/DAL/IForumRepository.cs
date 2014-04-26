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
        ForumModel GetBy(int postId);
        ICollection<ForumModel> GetForumBy(string user);

        void MarkRead(int id);

        void AddPost(string user, string title, string content, int course);

       /* TODO Implement these 
        void CreatePost(string userName, string title, string content);
        void UpdatePost(ForumModel post);
       */
    }

}