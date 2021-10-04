using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Infrastructure
{
    public interface IGroupService
    {
        List<Group> Get();
        List<Group> Get(int id);
        Group GetGroupById(int id);
        List<Student> Details(int id);
        void Edit(Group group);
        void Delete(Group group);
    }
}
