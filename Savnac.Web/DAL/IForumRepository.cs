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
        ICollection<ForumModel> GetForumBy(int courseId);
       /* TODO Implement these 
        void CreatePost(string userName, string title, string content);
        void UpdatePost(ForumModel post);
       */
    }

}