using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public partial class Users
    {
        public int UserID { get; set; }
        public string RealName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
