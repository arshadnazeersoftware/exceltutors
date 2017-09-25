using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using DataTransaction;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        public ActionResult QuestionPaper()
        {
            return View();
        }

        public ActionResult AddContent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(AcademicContent content)
        {
            
            return View();
        }

        public ActionResult ListContent()
        {
            
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}