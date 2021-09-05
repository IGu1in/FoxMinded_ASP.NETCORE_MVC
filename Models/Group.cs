using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Group
    {
        [Key]
        public int Group_ID { get; set; }

        public int? Course_ID { get; set; }
        public Course Course { get; set; }

        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }
    }
}