using System.Collections.Generic;
using System.Linq;
using WebApplication.Application;
using WebApplication.Models;

namespace WebApplication.Repository.Application
{
    public class CourseService : ICourseService
    {
        IRepository<Course> repository;
        IRepository<Group> repositoryGroup;

        public CourseService(IRepository<Course> repCourse, IRepository<Group> repGroup)
        {
            repository = repCourse;
            repositoryGroup = repGroup;
        }

        public List<Course> Get()
        {
            var courses = repository.Get().OrderBy(c => c.Name).ToList();

            return courses;
        }

        public List<Group> Details(int id)
        {
            var groups = repositoryGroup.Get().Where(g => g.CourseId == id).OrderBy(g => g.Name).ToList();

            return groups;
        }
    }
}