using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeTimeTrackingSystem.Controllers
{
    public class BaseController : Controller
    {
        protected string connectionString;

        public IEmployeesService _employeeService;

        public BaseController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }
}