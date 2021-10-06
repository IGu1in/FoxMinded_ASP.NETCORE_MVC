using System.Collections.Generic;
using WebApplication.ViewModels;
using WebApplication.Infrastructure;

namespace WebApplication.Application
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;

        public StudentService(IRepository<Student> repStudent)
        {
            _repository = repStudent;
        }

        public List<Student> Get()
        {
            return _repository.Get();
        }

        public List<Student> Get(int id)
        {
            return _repository.Get(id);
        }

        public Student GetById(int id)
        {
            return _repository.GetOne(id);
        }

        public void Edit(Student student)
        {
            _repository.Edit(student);
        }
    }
}