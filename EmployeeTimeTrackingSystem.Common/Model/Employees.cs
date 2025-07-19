using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public partial class Employees
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
