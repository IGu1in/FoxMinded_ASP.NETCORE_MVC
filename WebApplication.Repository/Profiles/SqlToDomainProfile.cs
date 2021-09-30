using AutoMapper;
using WebApplication.Repository.Models;

namespace WebApplication.Repository.Profiles
{
    public class SqlToDomainProfile : Profile
    {
        public SqlToDomainProfile()
        {
            CreateMap<Course, WebApplication.Models.Course>();
            CreateMap<Group, WebApplication.Models.Group>();
            CreateMap<Student, WebApplication.Models.Student>();
        }
    }
}
