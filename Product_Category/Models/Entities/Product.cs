using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Product_Category.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please put Product Name")]
        [StringLength(10, ErrorMessage = "Name must be in 10 charecters")]
        [MinLength(5)]
        public string ProductName { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Description { get; set; }
    }
}