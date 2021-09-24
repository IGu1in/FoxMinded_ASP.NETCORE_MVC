using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Application;

namespace WebApplication.Controllers
{
    public class GroupController : Controller
    {
        IGroupService service;
        IStudentService serviceStudent;

        public GroupController(IGroupService groupServ, IStudentService studentServ)
        {
            service = groupServ;
            serviceStudent = studentServ;
        }

        public ActionResult Groups()
        {
            var groups = service.Get();

            return View(groups);
        }

        public ActionResult DetailsGroup(int id, string name)
        {
            ViewBag.Name = name;
            var students = service.Details(id);

            return View(students);
        }

        [HttpGet]
        public ActionResult EditGroup(int id)
        {
            var groups = service.Get();
            var group = groups.Find(g => g.GroupId == id);

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
                service.Edit(group);

                return RedirectToAction("Groups");
            }

            return View(group);
        }

        [HttpGet]
        public ActionResult DeleteGroup(int id)
        {
            var groups = service.Get();
            var group = groups.Find(g => g.GroupId == id);

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

            if (serviceStudent.Get().Where(g => g.GroupId == group.GroupId).Count() > 0)
            {
                return RedirectToAction("DeleteGroupError");
            }
            else
            {
                service.Delete(group);

                return RedirectToAction("Groups");
            }
        }

        public ActionResult DeleteGroupError()
        {
            return View();
        }
    }
}