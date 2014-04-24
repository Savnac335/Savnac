using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Savnac.Web.Models
{
    public class Thread
    {
        public int ThreadId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }

        public int ForumId { get; set; }
        public virtual Forum Forum { get; set; }

        public List<Post> Posts { get; set; }
    }
}