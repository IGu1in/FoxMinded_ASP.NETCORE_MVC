using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Repository.Application
{
    public class StudentService
    {
        public static List<Student> Get()
        {
            var students = StudentRepository.Get().OrderBy(g => g.Group.Name).ThenBy(s => s.First_Name).ToList();

            return students;
        }

        public static void Edit(Student student)
        {
            StudentRepository.Edit(student);
        }
    }
}