namespace EmployeeTimeTrackingSystem.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Security.Cryptography;
    using EmployeeTimeTrackingSystem.Models;
    using System.Text;
    using System.Linq;
    using EmployeeTimeTrackingSystem.Helpers;
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;

    public class UserManagementController : Controller
    {
        private readonly IUserService _userService;

        public UserManagementController(IUserService userService)
        {
            _userService = userService;
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
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false, message = "Incorrect Username/Password" });
                }
                ModelState.AddModelError("", "Incorrect Username/Password");
                return View(user);
            }

            var hashedPass = HashPassword(user.Password);
            var userlog = _userService.Get(a => a.UserName == user.UserName && a.Password == hashedPass).FirstOrDefault();

            if (userlog != null)
            {
                Session["RealName"] = userlog.RealName;
                Session["RoleName"] = userlog.Role?.RoleName ?? "User";

                UserAuthentication.SetAuthentication(userlog);

                if (Request.IsAjaxRequest())
                {
                    string redirectUrl = (userlog.RoleID == 1) ? Url.Action("Index", "Branch") : Url.Action("Index", "Dashboard");
                    return Json(new { success = true, redirect = redirectUrl });
                }

                if (userlog.RoleID == 1)
                    return RedirectToAction("Index", "Branch");
                else
                    return RedirectToAction("Index", "Dashboard");
            }

            if (Request.IsAjaxRequest())
            {
                return Json(new { success = false, message = "The user name or password you’ve entered is incorrect" });
            }

            ModelState.AddModelError("", "The user name or password you’ve entered is incorrect");
            return View(user);
        }

        public static string HashPassword(string password)
        {
            byte[] salt;

            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("UserLogin");
        }
    }
}
