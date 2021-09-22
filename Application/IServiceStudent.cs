using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Application
{
    interface IServiceStudent
    {
        List<Student> Get();
        void Edit(Student student);
    }
}
