using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;
using DataTransaction;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(Models.UserAccount userAccount)
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
                //if (roles == admin)
                //{
                //}
                //else
                //{
                    return RedirectToAction("Index", "Home");
                //}
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
        public ActionResult Register(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                obj.Create(user.Username, user.Password, user.Email);
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