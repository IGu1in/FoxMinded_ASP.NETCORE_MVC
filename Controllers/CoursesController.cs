using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CoursesController : Controller
    {
        public ActionResult Courses()
        {
            using (UniversityContext db = new UniversityContext())
            {
                var courses = db.Courses.OrderBy(c => c.Name);
                return View(courses.ToList());
            }
        }

        public ActionResult DetailsCourse(int id, string name)
        {
            using (UniversityContext db = new UniversityContext())
            {
                ViewBag.Name = name;
                var groups = db.Groups.Where(g => g.Course_ID == id).OrderBy(g => g.Name);
                return View(groups.ToList());
            }
        }
    }
}