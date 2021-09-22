using Ninject;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Application;
using WebApplication.Repository.Application;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        IServiceStudent service;

        public StudentController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IServiceStudent>().To<StudentService>();
            service = ninjectKernel.Get<IServiceStudent>();
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
                service.Edit(student);

                return RedirectToAction("Students");
            }

            return View(student);
        }
    }
}