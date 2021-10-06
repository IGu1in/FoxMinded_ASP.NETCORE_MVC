using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }

        [RegularExpression(@"[A-Za-z-]+", ErrorMessage = "The name can contain only Latin letters")]
        [StringLength(20, ErrorMessage = "The maximum length is 25 characters")]
        public string FirstName { get; set; }

        [RegularExpression(@"[A-Za-z-]+", ErrorMessage = "The name can contain only Latin letters")]
        [StringLength(20, ErrorMessage = "The maximum length is 25 characters")]
        public string LastName { get; set; }
    }
}
