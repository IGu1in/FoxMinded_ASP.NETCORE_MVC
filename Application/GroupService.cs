using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Repository.Application
{
    public static class GroupService
    {
        public static List<Models.Group> Get()
        {
            var groups = GroupRepository.Get().OrderBy(g => g.Name).ToList();

            return groups;
        }
        public static List<Student> Details(int id)
        {            
            var students = StudentRepository.Get().Where(g => g.Group_ID == id).OrderBy(g => g.Group.Name).ThenBy(s => s.First_Name).ToList();

            return students;
        }

        public static void Edit(Models.Group group)
        {
            GroupRepository.Edit(group);
        }

        public static void Delete(Models.Group group)
        {
            GroupService.Delete(group);
        }
    }
}