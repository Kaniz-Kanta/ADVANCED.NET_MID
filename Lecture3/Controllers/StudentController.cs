using Lecture3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Lecture3.Models;
using Lecture3.Auth;

namespace Lecture3.Controllers
{
    [AdminAccess]
    public class StudentController : Controller
    {
        // GET: Student
        [Authorize]
        public ActionResult Index()
        {
            Database database = new Database();
            var students= database.Students.GetAllStudent();
            return View(students);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Student s = new Student();
            return View(s);
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid)//use for validation
            {
                Database database = new Database();
                database.Students.AddStudent(s);
                return RedirectToAction("Index");
            }
            return View(s);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Database database = new Database();
            var s = database.Students.GetStudentById(id);
            return View(s);
        }
    }
}