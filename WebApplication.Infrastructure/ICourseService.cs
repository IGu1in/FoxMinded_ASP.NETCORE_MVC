using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Infrastructure
{
    public interface ICourseService
    {
        List<Course> Get();
        List<Group> Details(int id);
    }
}
