using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        private IMapper _mapper;

        public StudentRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

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
                var students = db.Students.Include(g => g.Group).OrderBy(g => g.Group.Name).ThenBy(s => s.FirstName).ToList();

                return _mapper.Map<List<Student>>(students);
            }
        }

        public List<Student> Get(int id)
        {
            using (var db = new UniversityContext())
            {
                var students = db.Students.Include(g => g.Group).Where(g => g.GroupId == id).OrderBy(g => g.Group.Name).ThenBy(s => s.FirstName);

                return _mapper.Map<List<Student>>(students);
            }
        } 
        
        public Student GetOne(int id)
        {
            using (var db = new UniversityContext())
            {
                var students = db.Students.Include(g => g.Group).Where(s => s.StudentId == id).FirstOrDefault();

                return _mapper.Map<Student>(students);
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