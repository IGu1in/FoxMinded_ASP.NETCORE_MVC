using System.Collections.Generic;
using WebApplication.ViewModels;

namespace WebApplication.Infrastructure
{
    public interface IStudentService
    {
        List<Student> Get();
        List<Student> Get(int id);
        Student GetById(int id);
        void Edit(Student student);
    }
}
