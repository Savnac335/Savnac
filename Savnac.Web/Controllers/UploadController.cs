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


namespace Savnac.Web.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /Upload/

        public ActionResult UploadDocument()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (Request.Files.Count > 0)
            {
                file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    file.SaveAs(path);
                }
            }

            return View("UploadDocument");
        }

    }
}
