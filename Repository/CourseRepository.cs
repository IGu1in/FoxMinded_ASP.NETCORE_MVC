using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public class CourseRepository : IRepository<Course>
    {
        public void Create(Course course)
        {
            using (UniversityContext db = new UniversityContext())
            {
                    db.Courses.Add(course);
                    db.SaveChanges();
            }
        }

        public List<Course> Get()
        {
            using (UniversityContext db = new UniversityContext())
            {
                var courses = db.Courses.ToList();

                return courses;
            }
        }

        public void Edit(Course course)
        {
            using (UniversityContext db = new UniversityContext())
            {               
                    db.Entry(course).State = EntityState.Modified;
                    db.SaveChanges();
            }
        }

        public void Delete(Course course)
        {
            using (UniversityContext db = new UniversityContext())
            {
                db.Entry(course).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}