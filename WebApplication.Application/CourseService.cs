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

        public Course Get()
        {
            return repository.Get();
        }

        public Group Details(int id)
        {
            var groups = repositoryGroup.Get(id);

            return groups;
        }
    }
}