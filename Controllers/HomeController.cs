using System.Linq;
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

        public ActionResult Groups()
        {
            using (UniversityContext db = new UniversityContext())
            {
                var groups = db.Groups.Include(c => c.Course).OrderBy(g => g.Name);
                return View(groups.ToList());
            }
        }

        public ActionResult DetailsGroup(int id, string name)
        {
            using (UniversityContext db = new UniversityContext())
            {
                ViewBag.Name = name;
                var students = db.Students.Where(g => g.Group_ID == id).OrderBy(s => s.First_Name);
                return View(students.ToList());
            }
        }

        [HttpGet]
        public ActionResult EditGroup(int id)
        {
            using (UniversityContext db = new UniversityContext())
            {
                Group group = db.Groups.Find(id);

                if (group != null)
                {
                    return View(group);
                }

                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult EditGroup(Group group)
        {
            using (UniversityContext db = new UniversityContext())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(group).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Groups");
                }

                return View(group);
            }
        }

        [HttpGet]
        public ActionResult DeleteGroup(int id)
        {
            using (UniversityContext db = new UniversityContext()) 
            {
                Group group = db.Groups.Find(id);

                if (group == null)
                {
                    return HttpNotFound();
                }

                return View(group); 
            }
        }

        [HttpPost]
        public ActionResult DeleteGroup(Group group)
        {
            using (UniversityContext db = new UniversityContext())
            {
                if (group == null)
                {
                    return HttpNotFound();
                }

                if (db.Students.Where(g => g.Group_ID == group.Group_ID).Count() > 0)
                {
                    return RedirectToAction("DeleteGroupError");
                }
                else
                {
                    db.Entry(group).State = EntityState.Deleted;
                    db.SaveChanges();

                    return RedirectToAction("Groups");
                }
            }
        }

        public ActionResult DeleteGroupError()
        {
                return View();
        }

        public ActionResult Students()
        {
            using (UniversityContext db = new UniversityContext())
            {
                var students =  db.Students.Include(s => s.Group).OrderBy(g => g.Group.Name).ThenBy(s => s.First_Name);            

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