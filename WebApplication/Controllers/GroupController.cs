using System.Web.Mvc;
using WebApplication.ViewModels;
using WebApplication.Infrastructure;

namespace WebApplication.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService _service;
        private readonly IStudentService _serviceStudent;

        public GroupController(IGroupService groupService, IStudentService studentService)
        {
            _service = groupService;
            _serviceStudent = studentService;
        }

        public ActionResult Groups()
        {
            var groups = _service.Get();

            return View(groups);
        }

        public ActionResult DetailsGroup(int id, string name)
        {
            ViewBag.Name = name;
            var students = _service.Details(id);

            return View(students);
        }

        [HttpGet]
        public ActionResult EditGroup(int id)
        {
            var group = _service.GetGroupById(id);

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
                _service.Edit(group);

                return RedirectToAction("Groups");
            }

            return View(group);
        }

        [HttpGet]
        public ActionResult DeleteGroup(int id)
        {
            var group = _service.GetGroupById(id);

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

            if (_serviceStudent.Get(group.GroupId) != null)
            {
                return RedirectToAction("DeleteGroupError");
            }
            else
            {
                _service.Delete(group);

                return RedirectToAction("Groups");
            }
        }

        public ActionResult DeleteGroupError()
        {
            return View();
        }
    }
}