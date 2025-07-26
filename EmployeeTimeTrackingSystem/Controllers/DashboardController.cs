using System;
using System.Web.Mvc;
using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
using EmployeeTimeTrackingSystem.Common.Contracts.Service;
using EmployeeTimeTrackingSystem.Models;

namespace EmployeeTimeTrackingSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IEmployeesService _employeesService;
        private readonly ITimeEntriesService _attendanceService;

        public DashboardController(IEmployeesService employeesService, ITimeEntriesService attendanceService)
        {
            _employeesService = employeesService;
            _attendanceService = attendanceService;
        }

        public ActionResult Index()
        {
            var viewModel = new DashboardCardViewModel
            {
                TotalEmployees = _employeesService.Count(),
                PresentToday = _attendanceService.CountPresent(DateTime.Today),
                LateToday = _attendanceService.CountLate(DateTime.Today),
                AbsentToday = _attendanceService.CountAbsent(DateTime.Today)
            };

            return View(viewModel);
        }
    }
}
