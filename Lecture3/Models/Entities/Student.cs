using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecture3.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please put your Name")]
        [StringLength(10, ErrorMessage = "Name must be in 10 charecters")]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}