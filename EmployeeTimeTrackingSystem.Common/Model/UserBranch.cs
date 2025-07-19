using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public class UserBranch
    {
        [Key, Column(Order = 0)]
        public int UserID { get; set; }

        [Key, Column(Order = 1)]
        public int BranchID { get; set; }

        public virtual Users User { get; set; }
        public virtual Branches Branch { get; set; }
    }
}
