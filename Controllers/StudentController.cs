using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Application;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        IStudentService service;

        public StudentController(IStudentService studentServ)
        {
            service = studentServ;
        }

        public ActionResult Students()
        {
            var students = service.Get();

            return View(students);
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var students = service.Get();
            var student = students.Find(s => s.StudentId == id);

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
                service.Edit(student);

                return RedirectToAction("Students");
            }

            return View(student);
        }
    }
}