using System.Collections.Generic;
using WebApplication.Models;
using WebApplication.Repository;

namespace WebApplication.Application
{
    public class GroupService : IGroupService
    {
        IRepository<Group> repository;
        IRepository<Student> repositoryStudent;

        public GroupService(IRepository<Group> repGroup, IRepository<Student> repStudent)
        {
            repository = repGroup;
            repositoryStudent = repStudent;
        }

        public List<Group> Get()
        {
            return repository.Get();
        }

        public List<Group> Get(int id)
        {
            return repository.Get(id);
        }

        public Group GetGroupById(int id)
        {
            return repository.GetOne(id);
        }

        public List<Student> Details(int id)
        {
            var students = repositoryStudent.Get(id);

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