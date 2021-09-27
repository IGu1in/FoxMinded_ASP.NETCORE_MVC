﻿using System.Collections.Generic;
using System.Linq;
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
            return repository.Get().OrderBy(g => g.Name).ToList();
        }
        public List<Student> Details(int id)
        {
            var students = repositoryStudent.Get().Where(g => g.GroupId == id).OrderBy(g => g.Group.Name).ThenBy(s => s.FirstName).ToList();

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