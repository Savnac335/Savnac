using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Savnac.Web.Models;

namespace Savnac.Web.Controllers
{
    public class FilesController : Controller
    {
        //
        // GET: /Files/

        public ActionResult FilesView()
        {
            return View();
        }

        

        [Authorize]
        public ActionResult ViewFiles()
        {
            FilesList files = new FilesList();

            return View(files);
        }
    }
}
