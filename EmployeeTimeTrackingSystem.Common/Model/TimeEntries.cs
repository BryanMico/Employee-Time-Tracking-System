using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public class TimeEntries
    {
        [Key]
        public int EntryID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public DateTime ClockIn { get; set; }

        public DateTime? ClockOut { get; set; }

        public decimal? HoursWorked { get; set; }

        [StringLength(250)]
        public string Remarks { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
