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
            var db = new UMSEntities();
            var student = (from s in db.Students
                           where s.Id==Id
                           select s).FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            var db = new UMSEntities();
            var student = (from sd in db.Students
                           where sd.Id == s.Id
                           select sd).FirstOrDefault();
            /*student.Name = s.Name;
            student.Dob = s.Dob;
            student.Gender = s.Gender;
            db.SaveChanges();*/
            db.Entry(student).CurrentValues.SetValues(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {
            var db = new UMSEntities();
            var student = (from sd in db.Students
                           where sd.Id == s.Id
                           select sd).FirstOrDefault();
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}