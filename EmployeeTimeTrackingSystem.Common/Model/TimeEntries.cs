using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public partial class TimeEntries
    {
        public int EntryID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime ClockIn { get; set; }
        public Nullable<DateTime> ClockOut { get; set; }
        public Nullable<decimal> HoursWorked { get; set; }
        public string Remarks { get; set; }
    }
}
