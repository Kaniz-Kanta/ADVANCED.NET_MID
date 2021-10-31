using Lecture3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult LogIn()
        {

            return View();
        }
        [HttpPost]
        public ActionResult LogIn(string Username, string Password)
        {
            var db = new Database();
            var user = db.Users.Authentication(Username, Password);
            if(user!= null)
            {
                return RedirectToAction("Index", "Student");
            }
            return View();
        }
    }
}