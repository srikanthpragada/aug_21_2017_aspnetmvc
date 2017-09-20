using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class Customer
    {
        [Required]
        [StringLength(30,MinimumLength = 5,ErrorMessage = "Name must be atleast 5 chars")]
        public String Name { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage ="Mobile number must be 10 digits")]
        public String Mobile { get; set; }


        public int Age { get; set; }

    }
}