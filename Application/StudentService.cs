using Ninject;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Application;
using WebApplication.Models;

namespace WebApplication.Repository.Application
{
    public class StudentService : IServiceStudent
    {
        IRepository<Student> repository;

        public StudentService()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IRepository<Student>>().To<StudentRepository>();
            repository = ninjectKernel.Get<IRepository<Student>>();
        }

        public List<Student> Get()
        {
            var students = repository.Get().OrderBy(g => g.Group.Name).ThenBy(s => s.FirstName).ToList();

            return students;
        }

        public void Edit(Student student)
        {
            repository.Edit(student);
        }
    }
}