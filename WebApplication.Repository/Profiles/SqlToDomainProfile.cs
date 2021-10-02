using AutoMapper;
using WebApplication.Repository.Models;

namespace WebApplication.Repository.Profiles
{
    public class SqlToDomainProfile : Profile
    {
        public SqlToDomainProfile()
        {
            CreateMap<Course, WebApplication.Models.Course>()
                .ForMember(x=>x.Groups, y=>y.MapFrom(z=>z.Groups));
            CreateMap<Group, WebApplication.Models.Group>()
                 .ForMember(x => x.Students, y => y.MapFrom(z => z.Students)); 
            CreateMap<Student, WebApplication.Models.Student>();
        }
    }
}
