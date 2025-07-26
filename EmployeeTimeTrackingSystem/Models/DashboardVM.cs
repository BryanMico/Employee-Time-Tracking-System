using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTimeTrackingSystem.Models
{
    public class DashboardCardViewModel
    {
        public int TotalEmployees { get; set; }
        public int PresentToday { get; set; }
        public int LateToday { get; set; }
        public int AbsentToday { get; set; }
    }
}