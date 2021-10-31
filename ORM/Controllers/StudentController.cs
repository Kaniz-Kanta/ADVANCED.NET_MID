using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORM.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var db = new UMSEntities();
            var list= db.Students.ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            var db = new UMSEntities();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            var db = new UMSEntities();
            db.Students.Add(s);
            db.SaveChanges();// to set in database
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            return View();
        }
    }
}