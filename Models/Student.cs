using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Student
    {
        [Key]
        public int Student_ID { get; set; }

        public int? Group_ID { get; set; }
        public Group Group { get; set; }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }
    }
}