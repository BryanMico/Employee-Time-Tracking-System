namespace EmployeeTimeTrackingSystem.Controllers
{
    using EmployeeTimeTrackingSystem.Business;
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.DataAccess.Repositories;
    using System.Web.Mvc;

    public class EmployeesController : BaseController
    {
        private readonly IEmployeesService _employeeService;

        public EmployeesController(IEmployeesService employeeService)
        {
            _employeeService = employeeService;
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