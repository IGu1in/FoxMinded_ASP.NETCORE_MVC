using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Group 
    {
        [Key]
        public int GroupId { get; set; }

        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }
    }
}