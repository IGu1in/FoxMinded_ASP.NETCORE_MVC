using Ninject;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Application;
using WebApplication.Models;

namespace WebApplication.Repository.Application
{
    public class GroupService : IServiceGroup
    {
        IRepository<Group> repository;
        IRepository<Student> repositoryStudent;

        public GroupService()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IRepository<Group>>().To<GroupRepository>();
            repository = ninjectKernel.Get<IRepository<Group>>();
            ninjectKernel.Bind<IRepository<Student>>().To<StudentRepository>();
            repositoryStudent = ninjectKernel.Get<IRepository<Student>>();
        }

        public List<Group> Get()
        {
            var groups = repository.Get().OrderBy(g => g.Name).ToList();

            return groups;
        }
        public List<Student> Details(int id)
        {
            var students = repositoryStudent.Get().Where(g => g.Group_ID == id).OrderBy(g => g.Group.Name).ThenBy(s => s.FirstName).ToList();

            return students;
        }

        public void Edit(Group group)
        {
            repository.Edit(group);
        }

        public void Delete(Group group)
        {
            repository.Delete(group);
        }
    }
}