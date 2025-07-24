namespace EmployeeTimeTrackingSystem.Controllers
{
    using System.Web.Mvc;
    using EmployeeTimeTrackingSystem.Models;
    using System.Text;
    using EmployeeTimeTrackingSystem.Business;
    using EmployeeTimeTrackingSystem.DataAccess.Repositories;
    using System.Linq;
    using EmployeeTimeTrackingSystem.Helpers;

    public class UserManagementController : BaseController
    {

        private new readonly UserService _userService;

        public UserManagementController()
        {
            _userService = new UserService(new UserRepository(connectionString));
        }

        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogin(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Incorrect Username/Password");
                return View(user);
            }

            var pass = Md5Generator(user.Password);
            var userlog = _userService.Get(a => a.UserName == user.UserName && a.Password == pass).FirstOrDefault();

            if (userlog != null)
            {
                if (userlog.RoleID == 1)
                {
                    UserAuthentication.SetAuthentication(userlog);
                    return RedirectToAction("Index", "Branch");
                }
                else
                {
                    UserAuthentication.SetAuthentication(userlog);
                    return RedirectToAction("Index", "BranchPortal");
                }
            }

            ModelState.AddModelError("", "The user name or password you’ve entered is incorrect");
            return View("~/Views/UserManagement/UserLogin.cshtml", user);
        }


        public string Md5Generator(string password)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("UserLogin");
        }

    }
}