using AutoMapper;
using WebApplication.Repository.Models;

namespace WebApplication.Repository.Profiles
{
    public class DomainToSqlProfile : Profile
    {
        public DomainToSqlProfile()
        {
            CreateMap<WebApplication.Models.Course, Course>()
                .ForMember(x => x.CourseId, x => x.MapFrom(m => m.CourseId))
                .ForMember(x => x.Name, x => x.MapFrom(m => m.Name))
                .ForMember(x => x.Description, x => x.MapFrom(m => m.Description))
                .ForMember(x => x.Groups, x => x.MapFrom(m => m.Groups));
            CreateMap<WebApplication.Models.Group, Group>();
            CreateMap<WebApplication.Models.Student, Student>();
        }
    }
}
