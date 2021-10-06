using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "The maximum length is 25 characters")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<Group> Groups { get; set; }

        public Course()
        {
            Groups = new List<Group>();
        }
    }
}
