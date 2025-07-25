using EmployeeTimeTrackingSystem.Attributes;
using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
using EmployeeTimeTrackingSystem.Common.Contracts.Service;
using EmployeeTimeTrackingSystem.Helpers;
using EmployeeTimeTrackingSystem.Models;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeTimeTrackingSystem.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchesService _branchesService;

        public BranchController(IBranchesService branchesService)
        {
            _branchesService = branchesService;
        }

        [InPrivate]
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                var branches = _branchesService.GetAll();

                var vm = new BranchSelectionVM
                {
                    UserName = UserAuthentication.Username,
                    BranchList = branches.ToList(),
                    SelectedBranchId = null
                };

                return View("Index", vm);
            }

            var branch = _branchesService.Get(b => b.BranchID == id).FirstOrDefault();

            if (branch == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index", "Dashboard", new { branchId = branch.BranchID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectBranch(BranchSelectionVM model)
        {
            if (!model.SelectedBranchId.HasValue)
            {
                ModelState.AddModelError("SelectedBranchId", "Please select a branch.");
                model.BranchList = _branchesService.GetAll().ToList();
                return View("Index", model);
            }

            UserAuthentication.BranchID = model.SelectedBranchId.Value;
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
