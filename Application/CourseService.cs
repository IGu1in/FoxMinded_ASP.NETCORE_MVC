using Ninject;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Application;
using WebApplication.Models;

namespace WebApplication.Repository.Application
{
    public class CourseService : IServiceCourse
    {
        IRepository<Course> repository;
        IRepository<Group> repositoryGroup;

        public CourseService()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IRepository<Course>>().To<CourseRepository>();
            repository = ninjectKernel.Get<IRepository<Course>>();
            ninjectKernel.Bind<IRepository<Group>>().To<GroupRepository>();
            repositoryGroup = ninjectKernel.Get<IRepository<Group>>();
        }

        public List<Course> Get()
        {
            var courses = repository.Get().OrderBy(c => c.Name).ToList();

            return courses;
        }

        public List<Group> Details(int id)
        {
            var groups = repositoryGroup.Get().Where(g => g.Course_ID == id).OrderBy(g => g.Name).ToList();

            return groups;
        }
    }
}