using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Savnac.Web.Models;

namespace Savnac.Web.DAL
{
    public class ThreadRepository : IThreadRepository
    {
        private Savnac_ForumsContext context;

        public ThreadRepository(Savnac_ForumsContext context)
        {
            this.context = context;
        }

        public IEnumerable<Models.Thread> GetThreads()
        {
            return context.Threads.ToList();
        }

        public Models.Thread GetThreadById(int threadId)
        {
            return context.Threads.Find(threadId);
        }

        public void CreateThread(Models.Thread thread)
        {
            context.Threads.Add(thread);
        }

        public void DeleteThread(int threadId)
        {
            Thread thread = context.Threads.Find(threadId);
            context.Threads.Remove(thread);
        }

        public void UpdateThread(Models.Thread thread)
        {
            context.Entry(thread).State = EntityState.Modified;
        }

        public Models.Forum GetForum(int forumId)
        {
            return context.Forums.Find(forumId);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}