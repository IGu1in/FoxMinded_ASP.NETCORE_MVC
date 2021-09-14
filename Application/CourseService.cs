using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Repository.Application
{
    public static class CourseService
    {
        public static List<Course> Get()
        {
            var courses = CourseRepository.Get().OrderBy(c => c.Name).ToList();

            return courses;
        }

        public static List<Group> Details(int id)
        {
            var groups = GroupRepository.Get().Where(g => g.Course_ID == id).OrderBy(g => g.Name).ToList();

            return groups;
        }
    }
}