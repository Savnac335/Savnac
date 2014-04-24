using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Savnac.Web.Models
{
    public class ForumDbInitializer : DropCreateDatabaseAlways<Savnac_ForumsContext>
    {
        protected override void Seed(Savnac_ForumsContext context)
        {
            context.Forums.Add(new Forum { ForumId = 1, Title = "Gaming", Description = "Let's talk about games", Sequence = 1 });
            context.Forums.Add(new Forum { ForumId = 2, Title = "Web Development", Description = "ASP.NET MVC is pretty cool", Sequence = 2 });

            context.Threads.Add(new Thread
            {
                ThreadId = 1,
                ForumId = 1,
                Title = "Test general thread",
                DateCreated = DateTime.Now
            });

            context.Threads.Add(new Thread
            {
                ThreadId = 2,
                ForumId = 1,
                Title = "Test gaming thread",
                DateCreated = DateTime.Now
            });

            context.Threads.Add(new Thread
            {
                ThreadId = 3,
                ForumId = 1,
                Title = "I like League of Legends",
                DateCreated = DateTime.Now
            });

            base.Seed(context);
        }
    }
}