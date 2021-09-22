using System.Collections.Generic;
using System.Linq;
using WebApplication.Application;
using WebApplication.Models;

namespace WebApplication.Repository.Application
{
    public class CourseService : IServiceCourse
    {
        public List<Course> Get()
        {
            var repository = new CourseRepository();
            var courses = repository.Get().OrderBy(c => c.Name).ToList();

            return courses;
        }

        public List<Group> Details(int id)
        {
            var repositoryGroup = new GroupRepository();
            var groups = repositoryGroup.Get().Where(g => g.Course_ID == id).OrderBy(g => g.Name).ToList();

            return groups;
        }
    }
}