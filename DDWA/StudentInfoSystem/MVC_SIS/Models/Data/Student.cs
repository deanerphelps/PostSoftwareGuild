using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public decimal GPA { get; set; }
        [Required]
        public Address Address { get; set; }
        public Major Major { get; set; }
        public List<Course> Courses { get; set; }
    }
}