using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Student
    {
        [Key]
        public int Student_ID { get; set; }

        public int? Group_ID { get; set; }
        public Group Group { get; set; }

        [RegularExpression(@"[A-Za-z-]+", ErrorMessage = "The name can contain only Latin letters")]
        public string First_Name { get; set; }

        [RegularExpression(@"[A-Za-z-]+", ErrorMessage = "The name can contain only Latin letters")]
        public string Last_Name { get; set; }
    }
}