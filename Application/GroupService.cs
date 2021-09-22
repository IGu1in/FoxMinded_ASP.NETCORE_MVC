using System.Collections.Generic;
using System.Linq;
using WebApplication.Application;
using WebApplication.Models;

namespace WebApplication.Repository.Application
{
    public class GroupService : IServiceGroup
    {
        public List<Group> Get()
        {
            var repository = new GroupRepository();
            var groups = repository.Get().OrderBy(g => g.Name).ToList();

            return groups;
        }
        public List<Student> Details(int id)
        {
            var repositoryStudent = new StudentRepository();
            var students = repositoryStudent.Get().Where(g => g.Group_ID == id).OrderBy(g => g.Group.Name).ThenBy(s => s.FirstName).ToList();

            return students;
        }

        public void Edit(Group group)
        {
            var repository = new GroupRepository();
            repository.Edit(group);
        }

        public void Delete(Group group)
        {
            var repository = new GroupRepository();
            repository.Delete(group);
        }
    }
}