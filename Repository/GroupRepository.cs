using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public class GroupRepository : IRepository<Group>
    {
        public void Create(Group group)
        {
            using (UniversityContext db = new UniversityContext())
            {
                db.Groups.Add(group);
                db.SaveChanges();
            }
        }

        public List<Group> Get()
        {
            using (UniversityContext db = new UniversityContext())
            {
                var groups = db.Groups.Include(c => c.Course).ToList();

                return groups;
            }
        }

        public void Edit(Group group)
        {
            using (UniversityContext db = new UniversityContext())
            {             
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Group group)
        {
            using (UniversityContext db = new UniversityContext())
            {
                db.Entry(group).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}