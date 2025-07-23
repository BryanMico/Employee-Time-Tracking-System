using System.ComponentModel.DataAnnotations;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public class User_refPermission
    {
        [Key]
        public int PermissionID { get; set; }

        public int ParentID { get; set; }

        [Required, StringLength(100)]
        public string Permission { get; set; }

        [StringLength(200)]
        public string Url { get; set; }

        public int? Sort { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public bool? IsHide { get; set; }
    }
}
