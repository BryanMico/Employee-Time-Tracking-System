using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public class Schedules
    {
        [Key]
        public int ScheduleID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public TimeSpan ShiftStart { get; set; }

        [Required]
        public TimeSpan ShiftEnd { get; set; }

        [Required, StringLength(20)]
        public string DayOfWeek { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
