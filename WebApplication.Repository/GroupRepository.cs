using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Models;
using WebApplication.Infrastructure;

namespace WebApplication.Repository
{
    public class GroupRepository : IRepository<ViewModels.Group>
    {
        private readonly IMapper _mapper;

        public GroupRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Create(ViewModels.Group group)
        {
            using (var db = new UniversityContext())
            {
                db.Groups.Add(_mapper.Map<Group>(group));
                db.SaveChanges();
            }
        }

        public List<ViewModels.Group> Get()
        {
            using (var db = new UniversityContext())
            {
                var groups = db.Groups.Include(c => c.Course).OrderBy(g=>g.Name).ToList();

                return _mapper.Map<List<ViewModels.Group>>(groups);
            }
        }

        public List<ViewModels.Group> Get(int id)
        {
            using (var db = new UniversityContext())
            {
                var groups = db.Groups.Include(c => c.Course).Where(c => c.CourseId == id).OrderBy(g => g.Name);

                return _mapper.Map<List<ViewModels.Group>>(groups);
            }
        }
        
        public ViewModels.Group GetOne(int id)
        {
            using (var db = new UniversityContext())
            {
                var groups = db.Groups.Include(c => c.Course).Where(c => c.GroupId == id).FirstOrDefault();

                return _mapper.Map<ViewModels.Group>(groups);
            }
        }

        public void Edit(ViewModels.Group group)
        {
            using (var db = new UniversityContext())
            {             
                db.Entry(_mapper.Map<Group>(group)).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(ViewModels.Group group)
        {
            using (var db = new UniversityContext())
            {
                db.Entry(_mapper.Map<Group>(group)).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}