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
        public string PostTitle { get; set; }
        public string PostText { get; set; }
        public virtual UserProfile UProfile { get; set; }
    }
}