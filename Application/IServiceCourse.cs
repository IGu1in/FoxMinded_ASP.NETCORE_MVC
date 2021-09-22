using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Application
{
    interface IServiceCourse
    {
        List<Course> Get();
        List<Group> Details(int id);
    }
}
