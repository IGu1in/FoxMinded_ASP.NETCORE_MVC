using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Course
    {
        [Key]
        public int Course_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Group> Groups { get; set; }

        public Course()
        {
            Groups = new List<Group>();
        }
    }
}