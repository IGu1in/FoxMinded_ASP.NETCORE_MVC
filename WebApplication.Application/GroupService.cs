using System.Collections.Generic;
using WebApplication.Models;
using WebApplication.Repository;

namespace WebApplication.Application
{
    public class GroupService : IGroupService
    {
        private readonly IRepository <Group> _repository;
        private readonly IRepository<Student> _repositoryStudent;

        public GroupService(IRepository<Group> repGroup, IRepository<Student> repStudent)
        {
            _repository = repGroup;
            _repositoryStudent = repStudent;
        }

        public List<Group> Get()
        {
            return _repository.Get();
        }

        public List<Group> Get(int id)
        {
            return _repository.Get(id);
        }

        public Group GetGroupById(int id)
        {
            return _repository.GetOne(id);
        }

        public List<Student> Details(int id)
        {
            var students = _repositoryStudent.Get(id);

            return students;
        }

        public void Edit(Group group)
        {
            _repository.Edit(group);
        }

        public void Delete(Group group)
        {
            _repository.Delete(group);
        }
    }
}