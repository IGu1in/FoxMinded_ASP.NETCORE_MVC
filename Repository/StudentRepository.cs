using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public static class StudentRepository 
    {
        public static void Create(Student student)
        {
            using (UniversityContext db = new UniversityContext())
            {
                    db.Students.Add(student);
                    db.SaveChanges();
            }
        }

        public static List<Student> Get()
        {
            using (UniversityContext db = new UniversityContext())
            {
                var students = db.Students.Include(g => g.Group).ToList();

                return students;
            }
        }

        public static void Edit(Student student)
        {
            using (UniversityContext db = new UniversityContext())
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Delete(Student student)
        {
            using (UniversityContext db = new UniversityContext())
            {
                db.Entry(student).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}