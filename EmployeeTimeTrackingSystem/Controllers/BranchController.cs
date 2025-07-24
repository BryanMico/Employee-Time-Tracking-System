using EmployeeTimeTrackingSystem.Attributes;
using EmployeeTimeTrackingSystem.Business;
using EmployeeTimeTrackingSystem.DataAccess.Repositories;
using EmployeeTimeTrackingSystem.Helpers;
using EmployeeTimeTrackingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeTimeTrackingSystem.Controllers
{
    public class BranchController : BaseController
    {
        private new readonly BranchesService _branchesService;

        public BranchController()
        {
            _branchesService = new BranchesService(new BranchesRepository(connectionString));
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
                    BranchList = branches,
                    SelectedBranchId = null
                };

                return View("Index", vm); 
            }

            var branch = _branchesService.Get(b => b.BranchID == id).FirstOrDefault();
            if (branch == null)
                return HttpNotFound();

            var vmBranch = new BranchVM
            {
                BranchID = branch.BranchID,
                BranchName = branch.BranchName,
                IsDisabled = branch.IsDisabled,
            };

            return RedirectToAction("Dashboard", "Home", new { branchId = branch.BranchID });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectBranch(BranchSelectionVM model)
        {
            if (!model.SelectedBranchId.HasValue)
            {
                ModelState.AddModelError("SelectedBranchId", "Please select a branch.");
                model.BranchList = _branchesService.GetAll();
                return View(model);
            }

            UserAuthentication.BranchID = model.SelectedBranchId.Value;
            return RedirectToAction("Index", "Home");
        }
    }
}