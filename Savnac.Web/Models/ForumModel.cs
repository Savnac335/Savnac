using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Savnac.Web.Models
{
    public class ForumModel
    {
        public int postId { get; set; }

        public string title { get; set; }
        public string content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime datePosted { get; set; }

        public int courseId { get; set; }

        public string userName { get; set; }

        public bool isRead { get; set; }

    }
}