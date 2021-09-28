using Ninject.Modules;
using WebApplication.Application;
using WebApplication.Models;
using WebApplication.Repository;

namespace WebApplication.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ICourseService>().To<CourseService>();
            Bind<IGroupService>().To<GroupService>();
            Bind<IStudentService>().To<StudentService>();
            Bind<IRepository<Course>>().To<CourseRepository>();
            Bind<IRepository<Group>>().To<GroupRepository>();
            Bind<IRepository<Student>>().To<StudentRepository>();
        }
    }
}