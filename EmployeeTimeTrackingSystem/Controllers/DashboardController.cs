using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeTimeTrackingSystem.Controllers
{
    public class DashboardController : Controller
    {
        // GET: BranchPortal
        public ActionResult Index()
        {
            return View();
        }
    }
}