using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class StudentsController : Controller
    {
        public ActionResult Students()
        {
            using (UniversityContext db = new UniversityContext())
            {
                var students = db.Students.Include(s => s.Group).OrderBy(g => g.Group.Name).ThenBy(s => s.First_Name);

                return View(students.ToList());
            }
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            using (UniversityContext db = new UniversityContext())
            {
                Student student = db.Students.Find(id);

                if (student != null)
                {
                    return View(student);
                }

                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            using (UniversityContext db = new UniversityContext())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Students");
                }

                return View(student);
            }
        }
    }
}