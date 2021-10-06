using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        public int? CourseId { get; set; }
        public Course Course { get; set; }

        [RegularExpression(@"[A-Za-z\d-]+", ErrorMessage = "The name can contain only Latin letters or digits")]
        [StringLength(7, ErrorMessage = "The maximum length is 25 characters")]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }
    }
}
