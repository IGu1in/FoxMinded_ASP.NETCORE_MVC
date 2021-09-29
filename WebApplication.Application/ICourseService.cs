using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Application
{
    public interface ICourseService
    {
        Course Get();
        Group Details(int id);
    }
}
