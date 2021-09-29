using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Application
{
    public interface IGroupService
    {
        Group Get();
        Group Get(int id);
        Student Details(int id);
        void Edit(Group group);
        void Delete(Group group);
    }
}
