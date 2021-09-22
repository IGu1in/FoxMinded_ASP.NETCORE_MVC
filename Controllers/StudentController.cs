using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Repository.Application;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Students()
        {
            var service = new StudentService();
            var students = service.Get();

            return View(students);
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var service = new StudentService();
            var students = service.Get();
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
                var service = new StudentService();
                service.Edit(student);

                return RedirectToAction("Students");
            }

            return View(student);
        }
    }
}