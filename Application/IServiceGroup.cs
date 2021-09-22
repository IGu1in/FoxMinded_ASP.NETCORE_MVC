using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Application
{
    interface IServiceGroup
    {
        List<Group> Get();
        List<Student> Details(int id);
        void Edit(Group group);
        void Delete(Group group);
    }
}
