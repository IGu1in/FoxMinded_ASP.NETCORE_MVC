using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public class GroupRepository : IRepository<Group>
    {
        private IMapper _mapper;

        public GroupRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Create(Group group)
        {
            using (var db = new UniversityContext())
            {
                db.Groups.Add(group);
                db.SaveChanges();
            }
        }

        public Group Get()
        {
            using (var db = new UniversityContext())
            {
                var groups = db.Groups.Include(c => c.Course).OrderBy(g=>g.Name);

                return _mapper.Map<Group>(groups);
            }
        }

        public Group Get(int id)
        {
            using (var db = new UniversityContext())
            {
                var groups = db.Groups.Include(c => c.Course).Where(c => c.CourseId == id).OrderBy(g => g.Name);

                return _mapper.Map<Group>(groups);
            }
        }

        public void Edit(Group group)
        {
            using (var db = new UniversityContext())
            {             
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Group group)
        {
            using (var db = new UniversityContext())
            {
                db.Entry(group).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}