using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Models;
using WebApplication.Infrastructure;

namespace WebApplication.Repository
{
    public class CourseRepository : IRepository<ViewModels.Course>
    {
        private readonly IMapper _mapper;

        public CourseRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Create(ViewModels.Course course)
        {
            using (var db = new UniversityContext())
            {
                    db.Courses.Add(_mapper.Map<Course>(course));
                    db.SaveChanges();
            }
        }

        public List<ViewModels.Course> Get()
        {
            using (var db = new UniversityContext())
            {
                var courses =  db.Courses.OrderBy(c=>c.Name).ToList();

                return _mapper.Map<List<ViewModels.Course>>(courses);
            }
        }

        public List<ViewModels.Course> Get(int id)
        {
            using (var db = new UniversityContext())
            {
                var courses = db.Courses.Where(c => c.CourseId == id).OrderBy(c => c.Name);

                return _mapper.Map<List<ViewModels.Course>>(courses);
            }
        }

        public ViewModels.Course GetOne(int id)
        {
            using (var db = new UniversityContext())
            {
                var courses = db.Courses.Where(c => c.CourseId == id).FirstOrDefault();

                return _mapper.Map<ViewModels.Course>(courses);
            }
        }

        public void Edit(ViewModels.Course course)
        {
            using (var db = new UniversityContext())
            {               
                    db.Entry(_mapper.Map<Course>(course)).State = EntityState.Modified;
                    db.SaveChanges();
            }
        }

        public void Delete(ViewModels.Course course)
        {
            using (var db = new UniversityContext())
            {
                db.Entry(_mapper.Map<Course>(course)).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}