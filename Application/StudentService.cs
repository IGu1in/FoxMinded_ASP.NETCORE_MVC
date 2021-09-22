using System.Collections.Generic;
using System.Linq;
using WebApplication.Application;
using WebApplication.Models;

namespace WebApplication.Repository.Application
{
    public class StudentService : IServiceStudent
    {
        public List<Student> Get()
        {
            var repository = new StudentRepository();
            var students = repository.Get().OrderBy(g => g.Group.Name).ThenBy(s => s.FirstName).ToList();

            return students;
        }

        public void Edit(Student student)
        {
            var repository = new StudentRepository();
            repository.Edit(student);
        }
    }
}