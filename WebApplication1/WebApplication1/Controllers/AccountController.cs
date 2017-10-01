using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        User user = new User();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(Models.User userAccount)
        {
            if (!ModelState.IsValid)
            {
                return View(userAccount);
            }

            bool k = Membership.ValidateUser(userAccount.Username, userAccount.Password);
            if (k)
            {
                FormsAuthentication.SetAuthCookie(userAccount.Username, false);
                ViewBag.Welcome = String.Format("Welcome {0}", userAccount.Username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User this_user)
        {
            if (ModelState.IsValid)
            {
                //user.CreateUser(this_user.Username, this_user.Password, this_user.Email);
                return RedirectToAction("Login", "Account");
            }
            return View(user);
        }

        // POST: /Account/LogOff
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}