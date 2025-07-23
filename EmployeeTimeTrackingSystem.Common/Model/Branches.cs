using System.ComponentModel.DataAnnotations;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public class Branches
    {
        [Key]
        public int BranchID { get; set; }

        [Required, StringLength(100)]
        public string BranchName { get; set; }

        public bool IsDisabled { get; set; }
    }
}
