using System.Collections.Generic;
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
            return repository.Get();
        }

        public List<Group> Details(int id)
        {
            var groups = repositoryGroup.Get(id);

            return groups;
        }
    }
}