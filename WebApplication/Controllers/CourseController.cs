using System.Web.Mvc;
using WebApplication.Infrastructure;

namespace WebApplication.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService courseService)
        {
            _service = courseService;
        }

        public ActionResult Courses()
        {
            var courses = _service.Get();

            return View(courses);
        }

        public ActionResult DetailsCourse(int id, string name)
        {
            ViewBag.Name = name;
            var groups = _service.Details(id);

            return View(groups);
        }
    }
}