using AutoMapper;

namespace WebApplication.Repository.Profiles
{
    public class SqlToDomainProfile : Profile
    {
        public SqlToDomainProfile()
        {
            CreateMap<ViewModels.Course, WebApplication.Models.Course>()
                .ForMember(x => x.Groups, y => y.MapFrom(z => z.Groups));
            CreateMap<ViewModels.Group, WebApplication.Models.Group>()
                 .ForMember(x => x.Students, y => y.MapFrom(z => z.Students)); 
            CreateMap<ViewModels.Student, WebApplication.Models.Student>();
        }
    }
}
