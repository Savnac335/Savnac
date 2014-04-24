using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Savnac.Web.Models;

namespace Savnac.Web.DAL
{
    public interface IThreadRepository
    {
        IEnumerable<Thread> GetThreads();
        Thread GetThreadById(int threadId);
        void CreateThread(Thread thread);
        void DeleteThread(int threadId);
        void UpdateThread(Thread thread);
        Forum GetForum(int forumId);
    }
}