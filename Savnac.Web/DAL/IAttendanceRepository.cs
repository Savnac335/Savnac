using Savnac.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savnac.Web.DAL
{
    public interface IAttendanceRepository
    {
        void OnSave(string studentName, bool isPresent, DateTime currentDate);
    }
}
