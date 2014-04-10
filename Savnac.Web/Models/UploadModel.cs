using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Savnac.Web.Filters;
using Savnac.Web.Models;

namespace Savnac.Web.Models
{
    public class Upload
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public HttpPostedFileBase attachment { get; set; }
    }
}