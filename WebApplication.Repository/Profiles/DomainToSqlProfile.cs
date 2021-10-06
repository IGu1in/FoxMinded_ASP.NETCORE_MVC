using AutoMapper;

namespace WebApplication.Repository.Profiles
{
    public class DomainToSqlProfile : Profile
    {
        public DomainToSqlProfile()
        {
            CreateMap<WebApplication.Models.Course, ViewModels.Course>()
                .ForMember(x => x.Groups, y => y.MapFrom(z => z.Groups));
            CreateMap<WebApplication.Models.Group, ViewModels.Group>()
                .ForMember(x => x.Students, y => y.MapFrom(z => z.Students)); 
            CreateMap<WebApplication.Models.Student, ViewModels.Student>();
        }
    }
}
