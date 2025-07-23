using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public class AuditLogs
    {
        [Key]
        public int LogID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required, StringLength(100)]
        public string Action { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public virtual Users User { get; set; }
    }
}
