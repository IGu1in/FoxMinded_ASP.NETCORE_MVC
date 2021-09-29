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

        public Group Get()
        {
            return repository.Get();
        }

        public Group Get(int id)
        {
            return repository.Get(id);
        }

        public Student Details(int id)
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