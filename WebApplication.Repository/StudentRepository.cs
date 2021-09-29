using AutoMapper;
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

        public Student Get()
        {
            using (var db = new UniversityContext())
            {
                var students = db.Students.Include(g => g.Group).OrderBy(g => g.Group.Name).ThenBy(s => s.FirstName);

                return _mapper.Map<Student>(students);
            }
        }

        public Student Get(int id)
        {
            using (var db = new UniversityContext())
            {
                var students = db.Students.Include(g => g.Group).Where(g => g.GroupId == id).OrderBy(g => g.Group.Name).ThenBy(s => s.FirstName);

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