using AutoMapper;
using WebApplication.Repository.Models;

namespace WebApplication.Repository.Profiles
{
    public class SqlToDomainProfile : Profile
    {
        public SqlToDomainProfile()
        {
            CreateMap<Course, WebApplication.Models.Course>()
                .ForMember(x=>x.CourseId, x=>x.MapFrom(m=>m.CourseId))
                .ForMember(x=>x.Name, x=>x.MapFrom(m=>m.Name))
                .ForMember(x=>x.Description, x=>x.MapFrom(m=>m.Description))
                .ForMember(x=>x.Groups, x=>x.MapFrom(m=>m.Groups));
            CreateMap<Group, WebApplication.Models.Group>();
            CreateMap<Student, WebApplication.Models.Student>();
        }
    }
}
