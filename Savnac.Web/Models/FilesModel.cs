using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Savnac.Web.Models
{
    public class FilesModel
    {
        public string filename { get; set; }
    }

    public class FilesList
    {
        public List<FilesModel> Files { get; set; }

        public FilesList()
        {
            Files = new List<FilesModel>()
			{
				new FilesModel() { filename = "Pizza.txt" },
                new FilesModel() { filename = "Hamburger.txt" },
                new FilesModel() { filename = "Ziggy.txt" },
			};
        }
    }
}