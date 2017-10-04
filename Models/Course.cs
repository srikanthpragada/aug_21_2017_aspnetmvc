using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string  Name { get; set; }

        public int Fee { get; set; }

        [Range(5,100,ErrorMessage = "Invalid Duration. Must be between 5 to 100")] 
        public int Duration { get; set; }
        public string Prereq { get; set; }
    }
}