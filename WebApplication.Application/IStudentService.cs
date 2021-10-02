using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Application
{
    public interface IStudentService
    {
        List<Student> Get();
        List<Student> Get(int id);
        Student GetById(int id);
        void Edit(Student student);
    }
}
