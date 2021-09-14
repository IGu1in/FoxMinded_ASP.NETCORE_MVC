using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class GroupsController : Controller
    {
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
    }
}