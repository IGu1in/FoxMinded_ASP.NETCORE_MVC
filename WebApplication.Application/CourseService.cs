using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;
using WebApplication.Repository;

namespace WebApplication.Application
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
            return repository.Get().OrderBy(c => c.Name).ToList();
        }

        public List<Group> Details(int id)
        {
            var groups = repositoryGroup.Get().Where(g => g.CourseId == id).OrderBy(g => g.Name).ToList();

            return groups;
        }
    }
}