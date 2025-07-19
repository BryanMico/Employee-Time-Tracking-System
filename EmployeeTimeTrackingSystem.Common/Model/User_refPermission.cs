using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public partial class User_refPermission
    {
        public int PermissionID { get; set; }
        public int ParentID { get; set; }
        public string Permission { get; set; }
        public string Url { get; set; }
        public int? Sort { get; set; }
        public string Type { get; set; }
        public Nullable<bool> isHide { get; set; }
    }
}
