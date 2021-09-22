using Ninject;
using System.Web.Mvc;
using WebApplication.Application;
using WebApplication.Repository.Application;

namespace WebApplication.Controllers
{
    public class CourseController : Controller
    {
        IServiceCourse service;

        public CourseController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IServiceCourse>().To<CourseService>();
            service = ninjectKernel.Get<IServiceCourse>();
        }

        public ActionResult Courses()
        {
            var courses = service.Get();

            return View(courses);
        }

        public ActionResult DetailsCourse(int id, string name)
        {
            ViewBag.Name = name;
            var groups = service.Details(id);

            return View(groups);
        }
    }
}