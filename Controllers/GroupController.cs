using Ninject;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Application;
using WebApplication.Repository.Application;

namespace WebApplication.Controllers
{
    public class GroupController : Controller
    {
        IServiceGroup service;
        IServiceStudent serviceStudent;

        public GroupController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IServiceGroup>().To<GroupService>();
            service = ninjectKernel.Get<IServiceGroup>();
            ninjectKernel.Bind<IServiceStudent>().To<StudentService>();
            serviceStudent = ninjectKernel.Get<IServiceStudent>();
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
                service.Edit(group);

                return RedirectToAction("Groups");
            }

            return View(group);
        }

        [HttpGet]
        public ActionResult DeleteGroup(int id)
        {
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