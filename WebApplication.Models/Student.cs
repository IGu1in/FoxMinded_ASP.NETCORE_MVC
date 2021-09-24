using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Student 
    {
        [Key]
        public int StudentId { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }

        [RegularExpression(@"[A-Za-z-]+", ErrorMessage = "The name can contain only Latin letters")]
        public string FirstName { get; set; }

        [RegularExpression(@"[A-Za-z-]+", ErrorMessage = "The name can contain only Latin letters")]
        public string LastName { get; set; }
    }
}