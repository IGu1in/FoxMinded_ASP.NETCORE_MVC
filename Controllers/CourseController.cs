using System.Web.Mvc;
using WebApplication.Repository.Application;

namespace WebApplication.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Courses()
        {
            var service = new CourseService();
            var courses = service.Get();

            return View(courses);
        }

        public ActionResult DetailsCourse(int id, string name)
        {
            var service = new CourseService();
            ViewBag.Name = name;
            var groups = service.Details(id);

            return View(groups);
        }
    }
}