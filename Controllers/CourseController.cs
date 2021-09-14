using System.Web.Mvc;
using WebApplication.Repository.Application;

namespace WebApplication.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Courses()
        {
            var courses = CourseService.Get();

            return View(courses);
        }

        public ActionResult DetailsCourse(int id, string name)
        {
            ViewBag.Name = name;
            var groups = CourseService.Details(id);

            return View(groups);
        }
    }
}