using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Student 
    {
        [Key]
        public int StudentId { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}