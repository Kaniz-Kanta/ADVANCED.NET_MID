using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture1.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult List()
        {
            //ViewBag.Name = "Kanta";
            // ViewData["Name"] = "Kaniz Fatema";
            string[] names = new string[5];
            names[0] = "Karim";
            names[1] = "Rahim";
            names[2] = "Sabuz";
            names[3] = "Arif";
            names[4] = "Kakon";
            ViewBag.Names = names;
            return View();
        }
        public ActionResult AddPerson()
        {
            return View();
        }
    }
}