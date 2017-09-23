using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mvcdemo.Controllers
{
    public class UserController : Controller
    {
        [Authorize] 
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            return Content("<h2>Srikanth Technologies</h2>");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string returnUrl)
        {
            var user = UserRepository.GetUser()
                 .Where(u => u.Username == username && u.Password == password)
                 .SingleOrDefault();

            if (user == null)  // Invalid user so return with message
            {
                ViewBag.Message = "Sorry! Invalid Login!";
                return View();
            }

            FormsAuthentication.SetAuthCookie(username, false);
            return Redirect(returnUrl ?? "/User/Index");
        }
    }
}