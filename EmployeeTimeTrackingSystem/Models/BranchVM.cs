using EmployeeTimeTrackingSystem.Common.Model;
using System.Collections.Generic;

namespace EmployeeTimeTrackingSystem.Models
{
    public class BranchVM
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public bool IsDisabled { get; set; }

        public int EmployeeCount { get; set; }
        public string BranchManagerName { get; set; }


    }

    public class BranchSelectionVM
    {
        public string UserName { get; set; }

        public int? SelectedBranchId { get; set; }
        public IEnumerable<Branches> BranchList { get; set; }
    }
}
