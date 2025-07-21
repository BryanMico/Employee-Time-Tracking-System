using EmployeeTimeTrackingSystem.Business;
using EmployeeTimeTrackingSystem.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeTimeTrackingSystem.Controllers
{
    public class EmployeesController : BaseController
    {
        public EmployeesController()
        {
            _employeeService = new EmployeesService(new EmployeesRepository(connectionString));
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            var model = _employeeService.GetAll();
            return PartialView("_List", model);
        }
    }
}