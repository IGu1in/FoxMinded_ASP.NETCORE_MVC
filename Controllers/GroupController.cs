using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Repository.Application;

namespace WebApplication.Controllers
{
    public class GroupController : Controller
    {
        public ActionResult Groups()
        {
            var groups = GroupService.Get();

            return View(groups);
        }

        public ActionResult DetailsGroup(int id, string name)
        {
            ViewBag.Name = name;
            var students = GroupService.Details(id);

            return View(students);
        }

        [HttpGet]
        public ActionResult EditGroup(int id)
        {
            var groups = GroupService.Get();
            var group = groups.Find(g => g.Group_ID == id);

            if (group != null)
            {
                return View(group);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditGroup(Group group)
        {
            if (ModelState.IsValid)
            {
                GroupService.Edit(group);

                return RedirectToAction("Groups");
            }

            return View(group);
        }

        [HttpGet]
        public ActionResult DeleteGroup(int id)
        {
            var groups = GroupService.Get();
            var group = groups.Find(g => g.Group_ID == id);

            if (group != null)
            {
                return View(group);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult DeleteGroup(Group group)
        {
            if (group == null)
            {
                return HttpNotFound();
            }

            if (StudentService.Get().Where(g => g.Group_ID == group.Group_ID).Count() > 0)
            {
                return RedirectToAction("DeleteGroupError");
            }
            else
            {
                GroupService.Delete(group);

                return RedirectToAction("Groups");
            }
        }

        public ActionResult DeleteGroupError()
        {
            return View();
        }
    }
}