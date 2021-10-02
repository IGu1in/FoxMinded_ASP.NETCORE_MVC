using AutoMapper;
using WebApplication.Repository.Models;

namespace WebApplication.Repository.Profiles
{
    public class DomainToSqlProfile : Profile
    {
        public DomainToSqlProfile()
        {
            CreateMap<WebApplication.Models.Course, Course>()
                .ForMember(x => x.Groups, y => y.MapFrom(z => z.Groups));
            CreateMap<WebApplication.Models.Group, Group>()
                .ForMember(x => x.Students, y => y.MapFrom(z => z.Students)); 
            CreateMap<WebApplication.Models.Student, Student>();
        }
    }
}
