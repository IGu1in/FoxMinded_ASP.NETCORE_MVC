using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Application
{
    public interface IStudentService
    {
        List<Student> Get();
        void Edit(Student student);
    }
}
