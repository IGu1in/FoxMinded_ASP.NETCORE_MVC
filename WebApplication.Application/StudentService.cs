using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;
using WebApplication.Repository;

namespace WebApplication.Application
{
    public class StudentService : IStudentService
    {
        IRepository<Student> repository;

        public StudentService(IRepository<Student> repStudent)
        {
            repository = repStudent;
        }

        public List<Student> Get()
        {
            return repository.Get().OrderBy(g => g.Group.Name).ThenBy(s => s.FirstName).ToList();
        }

        public void Edit(Student student)
        {
            repository.Edit(student);
        }
    }
}