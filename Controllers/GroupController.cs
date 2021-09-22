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
            var service = new GroupService();
            var groups = service.Get();

            return View(groups);
        }

        public ActionResult DetailsGroup(int id, string name)
        {
            var service = new GroupService();
            ViewBag.Name = name;
            var students = service.Details(id);

            return View(students);
        }

        [HttpGet]
        public ActionResult EditGroup(int id)
        {
            var service = new GroupService();
            var groups = service.Get();
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
                var service = new GroupService();
                service.Edit(group);

                return RedirectToAction("Groups");
            }

            return View(group);
        }

        [HttpGet]
        public ActionResult DeleteGroup(int id)
        {
            var service = new GroupService();
            var groups = service.Get();
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
            var serviceGroup = new GroupService();
            var serviceStudent = new StudentService();
            if (group == null)
            {
                return HttpNotFound();
            }

            if (serviceStudent.Get().Where(g => g.Group_ID == group.Group_ID).Count() > 0)
            {
                return RedirectToAction("DeleteGroupError");
            }
            else
            {
                serviceGroup.Delete(group);

                return RedirectToAction("Groups");
            }
        }

        public ActionResult DeleteGroupError()
        {
            return View();
        }
    }
}