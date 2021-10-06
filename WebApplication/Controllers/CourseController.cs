using System.Web.Mvc;
using WebApplication.Infrastructure;
using WebApplication.ViewModels;

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

        [HttpGet]
        public ActionResult CreateCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                _service.Create(course);

                return RedirectToAction("Courses");
            }

            return View();
        }
    }
}