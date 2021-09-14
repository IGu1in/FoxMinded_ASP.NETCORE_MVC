using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Repository.Application;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Students()
        {
            var students = StudentService.Get();

            return View(students);
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var students = StudentService.Get();
            var student = students.Find(s => s.Student_ID == id);

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
                StudentService.Edit(student);

                return RedirectToAction("Students");
            }

            return View(student);
        }
    }
}