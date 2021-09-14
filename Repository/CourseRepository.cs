using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public static class CourseRepository 
    {
        public static void Create(Course course)
        {
            using (UniversityContext db = new UniversityContext())
            {
                    db.Courses.Add(course);
                    db.SaveChanges();
            }
        }

        public static List<Course> Get()
        {
            using (UniversityContext db = new UniversityContext())
            {
                var courses = db.Courses.ToList();

                return courses;
            }
        }

        public static void Edit(Course course)
        {
            using (UniversityContext db = new UniversityContext())
            {               
                    db.Entry(course).State = EntityState.Modified;
                    db.SaveChanges();
            }
        }

        public static void Delete(Course course)
        {
            using (UniversityContext db = new UniversityContext())
            {
                db.Entry(course).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}