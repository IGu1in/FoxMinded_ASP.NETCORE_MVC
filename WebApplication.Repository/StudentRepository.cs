using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student student)
        {
            using (var db = new UniversityContext())
            {
                db.Students.Add((Student)student);
                db.SaveChanges();
            }
        }

        public List<Student> Get()
        {
            using (var db = new UniversityContext())
            {
                var students = db.Students.Include(g => g.Group).ToList();

                return students;
            }
        }

        public void Edit(Student student)
        {
            using (var db = new UniversityContext())
            {              
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Student student)
        {
            using (var db = new UniversityContext())
            {
                db.Entry(student).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}