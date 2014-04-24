using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Savnac.Web.Models
{
    public class Savnac_ForumsContext: DbContext
    {
        public Savnac_ForumsContext()
            : base("Savnac_ForumsContext")
        {

        }

        public DbSet<Forum> Forums { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}