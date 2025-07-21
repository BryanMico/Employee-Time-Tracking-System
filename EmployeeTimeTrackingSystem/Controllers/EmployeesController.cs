namespace EmployeeTimeTrackingSystem.Controllers
{
    using EmployeeTimeTrackingSystem.Business;
    using EmployeeTimeTrackingSystem.DataAccess.Repositories;
    using System.Web.Mvc;

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