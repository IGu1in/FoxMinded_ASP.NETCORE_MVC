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

        public Student Get()
        {
            return repository.Get();
        }

        public Student Get(int id)
        {
            return repository.Get(id);
        }

        public Student GetGroup(int id)
        {
            return repository.Get(id);
        }

        public void Edit(Student student)
        {
            repository.Edit(student);
        }
    }
}