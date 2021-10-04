using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly IMapper _mapper;

        public CourseRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Create(Course course)
        {
            using (var db = new UniversityContext())
            {
                    db.Courses.Add(course);
                    db.SaveChanges();
            }
        }

        public List<Course> Get()
        {
            using (var db = new UniversityContext())
            {
                var courses =  db.Courses.OrderBy(c=>c.Name).ToList();

                return _mapper.Map<List<Course>>(courses);
            }
        }

        public List<Course> Get(int id)
        {
            using (var db = new UniversityContext())
            {
                var courses = db.Courses.Where(c => c.CourseId == id).OrderBy(c => c.Name);

                return _mapper.Map<List<Course>>(courses);
            }
        }

        public Course GetOne(int id)
        {
            using (var db = new UniversityContext())
            {
                var courses = db.Courses.Where(c => c.CourseId == id).FirstOrDefault();

                return _mapper.Map<Course>(courses);
            }
        }

        public void Edit(Course course)
        {
            using (var db = new UniversityContext())
            {               
                    db.Entry(course).State = EntityState.Modified;
                    db.SaveChanges();
            }
        }

        public void Delete(Course course)
        {
            using (var db = new UniversityContext())
            {
                db.Entry(course).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}