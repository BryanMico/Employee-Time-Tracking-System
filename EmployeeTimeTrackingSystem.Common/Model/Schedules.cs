using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public class Schedules
    {
        public int ScheduleID { get; set; }
        public int EmployeeID { get; set; }
        public TimeSpan ShiftStart { get; set; }
        public TimeSpan ShiftEnd { get; set; }
        public string DayOfWeek { get; set; }
    }
}
