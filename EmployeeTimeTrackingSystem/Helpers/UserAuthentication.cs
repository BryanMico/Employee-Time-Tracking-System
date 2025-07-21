namespace EmployeeTimeTrackingSystem.Helpers
{
    using EmployeeTimeTrackingSystem.Common.Model;
    using System;
    using System.Web;

    public class UserAuthentication
    {
        public static int UserId
        {
            get
            {
                int userId;
                var userTemp = HttpContext.Current.Session["UserId"];
                return Int32.TryParse(userTemp != null ? userTemp.ToString() : "0", out userId) ? userId : 0;
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }

        public static string Username
        {
            get
            {
                var username = HttpContext.Current.Session["Username"];
                return username != null ? username.ToString() : string.Empty;
            }
            set
            {
                HttpContext.Current.Session["Username"] = value;
            }
        }

        public static string UserRealname
        {
            get
            {
                var realname = HttpContext.Current.Session["UserRealname"];
                return realname != null ? realname.ToString() : string.Empty;
            }
            set
            {
                HttpContext.Current.Session["UserRealname"] = value;
            }
        }

        public static int UserLevelId
        {
            get
            {
                int roleId;
                var roleTemp = HttpContext.Current.Session["RoleId"];
                return Int32.TryParse(roleTemp != null ? roleTemp.ToString() : "0", out roleId) ? roleId : 0;
            }
            set
            {
                HttpContext.Current.Session["RoleId"] = value;
            }
        }

        public static string UserLevelname
        {
            get
            {
                var roleName = HttpContext.Current.Session["RoleName"].ToString();
                return roleName != null ? roleName.ToString() : string.Empty;
            }
            set
            {
                HttpContext.Current.Session["RoleName"] = value;
            }
        }
        public static string Department
        {
            get
            {
                var Department = HttpContext.Current.Session["Department"].ToString();
                return Department != null ? Department.ToString() : string.Empty;
            }
            set
            {
                HttpContext.Current.Session["Department"] = value;
            }
        }

        public static int BranchID
        {
            get
            {

                int branchId;
                var branchTemp = HttpContext.Current.Session["BranchID"];
                return Int32.TryParse(branchTemp != null ? branchTemp.ToString() : "0", out branchId) ? branchId : 0;


            }
            set
            {
                HttpContext.Current.Session["BranchID"] = value;
            }
        }

        public static void SetAuthentication(Users user)
        {
            UserId = user.UserID;
            Username = user.UserName;
            UserRealname = user.RealName;
            BranchID = 0;
        }
    }
}