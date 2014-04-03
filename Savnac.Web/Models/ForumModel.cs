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
        public int ThreadID { get; set; }
        public string THreadText { get; set; }
        public string ThreadTitle { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    
        public virtual ICollection<Post> Posts { get; set; }
    }


    public class Post
    {
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostText { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public virtual Thread Thread { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Thread")]
        public int ThreadID { get; set; }
    }
}