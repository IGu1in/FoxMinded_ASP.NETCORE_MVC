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

        [RegularExpression(@"[A-Za-z\d-]+", ErrorMessage = "The name can contain only Latin letters or digits")]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }
    }
}