using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public class Branches
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public bool IsDisabled { get; set; }
    }
}
