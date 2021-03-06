using System.Collections.Generic;
using WebApplication.Infrastructure;
using WebApplication.ViewModels;


namespace WebApplication.Application
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _repository;
        private readonly IRepository<Group> _repositoryGroup;

        public CourseService(IRepository<Course> repCourse, IRepository<Group> repGroup)
        {
            _repository = repCourse;
            _repositoryGroup = repGroup;
        }

        public List<Course> Get()
        {
            return _repository.Get();
        }

        public List<Group> Details(int id)
        {
            var groups = _repositoryGroup.Get(id);

            return groups;
        }

        public void Create(Course course)
        {
            _repository.Create(course);
        }
    }
}