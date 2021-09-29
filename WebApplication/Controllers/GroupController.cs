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

        public GroupController(IGroupService groupService, IStudentService studentService)
        {
            service = groupService;
            serviceStudent = studentService;
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
            var group = service.Get(id);

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
            var group = service.Get(id);

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

            if (serviceStudent.Get(group.GroupId) != null)
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