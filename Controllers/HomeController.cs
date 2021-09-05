using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using System.Data.Entity;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Courses()
        {
            using (UniversityContext db = new UniversityContext())
            {
                var courses = db.Courses;
                return View(courses.ToList());
            }
        }

        public ActionResult DetailsCourse(int id, string name)
        {
            using (UniversityContext db = new UniversityContext())
            {
                ViewBag.Name = name;
                var groups = db.Groups.Where(g => g.Course_ID == id);
                return View(groups.ToList());
            }
        }

        public ActionResult Groups()
        {
            using (UniversityContext db = new UniversityContext())
            {
                var groups = db.Groups.Include(g => g.Course);
                return View(groups.ToList());
            }
        }

        public ActionResult DetailsGroup(int id, string name)
        {
            using (UniversityContext db = new UniversityContext())
            {
                ViewBag.Name = name;
                var students = db.Students.Where(g => g.Group_ID == id);
                return View(students.ToList());
            }
        }

        public ActionResult Students()
        {
            using (UniversityContext db = new UniversityContext())
            {
                var students = db.Students.Include(s => s.Group);
                return View(students.ToList());
            }
        }
    }
}