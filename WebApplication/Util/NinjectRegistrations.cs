using AutoMapper;
using Ninject.Modules;
using WebApplication.Application;
using WebApplication.Models;
using WebApplication.Repository;
using WebApplication.Repository.Profiles;
using WebApplication.Infrastructure;

namespace WebApplication.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ICourseService>().To<CourseService>();
            Bind<IGroupService>().To<GroupService>();
            Bind<IStudentService>().To<StudentService>();
            Bind<IRepository<ViewModels.Course>>().To<CourseRepository>();
            Bind<IRepository<ViewModels.Group>>().To<GroupRepository>();
            Bind<IRepository<ViewModels.Student>>().To<StudentRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SqlToDomainProfile>();
                cfg.AddProfile<DomainToSqlProfile>();
            }
            );
            this.Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
        }
    }
}