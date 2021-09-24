using System.Web.Mvc;
using WebApplication.Application;

namespace WebApplication.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService service;

        public CourseController(ICourseService courseServ)
        {
            service = courseServ;
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