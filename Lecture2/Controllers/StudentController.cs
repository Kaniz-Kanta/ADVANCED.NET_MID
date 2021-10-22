using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lecture2.Models;
using System.Web.Mvc;

namespace Lecture2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Create()
        {
            Student s1 = new Student()//s1= instance
            {
                Id="12345",
                Name="Kaniz Fatema",
                Dob="22.02.2001"
            };
            return View(s1); // for sent the s1 instance we have to write it in view mathod
        }
        public ActionResult List()
        {
            List<Student> students = new List<Student>();
            for(int i=0; i<10; i++)
            {
                Student s1 = new Student()//s1= instance
                {
                    Id = "123"+(i+1),
                    Name = "Kaniz Fatema",
                    Dob = "22.02.2001"
                };
                students.Add(s1);
            }
            return View(students);
        }
        [HttpPost]//annotation
        public ActionResult CreateSubmit(Student s) 
        {

            //return RedirectToAction("Index");
            //Form Value Retrive Way

            //------using Request Class-----
            //HTTP Base Request Class ar Instantce "Request"
            /*ViewBag.Name = Request["name"].ToString(); // here name is the form index name of Name
            ViewBag.Id = Request["id"].ToString(); //here id is the form index name od ID
            ViewBag.Dob = Request["dob"].ToString();*/

            //------Using Form Collection Object----- //FormCollection fc as perameter
            /*ViewBag.Name= fc["name"].ToString();
            ViewBag.Id= fc["id"].ToString();
            ViewBag.Dob= fc["dob"].ToString();*/

            //-----Using Direct Variable------- //string name, string id, string dob as perameter
            /*ViewBag.Name = name;
            ViewBag.Id =id;
            ViewBag.Dob =dob;*/

            //-------using Model-------

            return View(s);
        }
    }
}