using System.Collections.Generic;
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
            return repository.Get();
        }

        public List<Student> Get(int id)
        {
            return repository.Get(id);
        }

        public Student GetById(int id)
        {
            return repository.GetOne(id);
        }

        public void Edit(Student student)
        {
            repository.Edit(student);
        }
    }
}