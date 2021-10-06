using System.Web.Mvc;
using WebApplication.ViewModels;
using WebApplication.Infrastructure;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService studentService)
        {
            _service = studentService;
        }

        public ActionResult Students()
        {
            var students = _service.Get();

            return View(students);
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var student = _service.GetById(id);

            if (student != null)
            {
                return View(student);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(student);

                return RedirectToAction("Students");
            }

            return View(student);
        }
    }
}