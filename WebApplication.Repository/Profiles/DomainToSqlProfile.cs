using AutoMapper;
using WebApplication.Repository.Models;

namespace WebApplication.Repository.Profiles
{
    public class DomainToSqlProfile : Profile
    {
        public DomainToSqlProfile()
        {
            CreateMap<WebApplication.Models.Course, Course>();
            CreateMap<WebApplication.Models.Group, Group>();
            CreateMap<WebApplication.Models.Student, Student>();
        }
    }
}
