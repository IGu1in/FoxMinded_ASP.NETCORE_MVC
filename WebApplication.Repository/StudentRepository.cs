using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Models;
using WebApplication.Infrastructure;

namespace WebApplication.Repository
{
    public class StudentRepository : IRepository<ViewModels.Student>
    {
        private readonly IMapper _mapper;

        public StudentRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Create(ViewModels.Student student)
        {
            using (var db = new UniversityContext())
            {
                db.Students.Add(_mapper.Map<Student>(student));
                db.SaveChanges();
            }
        }

        public List<ViewModels.Student> Get()
        {
            using (var db = new UniversityContext())
            {
                var students = db.Students.Include(g => g.Group).OrderBy(g => g.Group.Name).ThenBy(s => s.FirstName).ToList();

                return _mapper.Map<List<ViewModels.Student>>(students);
            }
        }

        public List<ViewModels.Student> Get(int id)
        {
            using (var db = new UniversityContext())
            {
                var students = db.Students.Include(g => g.Group).Where(g => g.GroupId == id).OrderBy(g => g.Group.Name).ThenBy(s => s.FirstName);

                return _mapper.Map<List<ViewModels.Student>>(students);
            }
        } 
        
        public ViewModels.Student GetOne(int id)
        {
            using (var db = new UniversityContext())
            {
                var students = db.Students.Include(g => g.Group).Where(s => s.StudentId == id).FirstOrDefault();

                return _mapper.Map<ViewModels.Student>(students);
            }
        }

        public void Edit(ViewModels.Student student)
        {
            using (var db = new UniversityContext())
            {              
                db.Entry(_mapper.Map<Student>(student)).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(ViewModels.Student student)
        {
            using (var db = new UniversityContext())
            {
                db.Entry(_mapper.Map<Student>(student)).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}