using System.Collections.Generic;
using WebApplication.ViewModels;

namespace WebApplication.Infrastructure
{
    public interface ICourseService
    {
        List<Course> Get();
        List<Group> Details(int id);
        void Create(Course course);
    }
}
