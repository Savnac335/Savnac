using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Savnac.Web.Models
{
    public class ForumModel
    {
        public int postId { get; set; }
        public string postTitle { get; set; }
        public string postContent { get; set; }
        public DateTime postTime { get; set; }
        public string postUsername { get; set; }

    }
}