using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public class CourseRepository : IRepository<Course>
    {
        private IMapper _mapper;

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

        public async Task<List<Course>> Get()
        {
            using (var db = new UniversityContext())
            {
                var courses = await db.Courses.ToList();

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