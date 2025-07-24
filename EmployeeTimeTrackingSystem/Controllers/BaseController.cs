namespace EmployeeTimeTrackingSystem.Controllers
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using System.Configuration;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        protected string connectionString;

        public IEmployeesService _employeeService;
        public IUserService _userService;
        public IBranchesService _branchesService;

        public BaseController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }
}