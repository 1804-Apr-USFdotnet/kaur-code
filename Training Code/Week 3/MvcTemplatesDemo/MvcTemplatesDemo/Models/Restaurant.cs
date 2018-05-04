using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTemplatesDemo.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "No names longer than 20 characters")]
        public string Name { get; set; }
        [Required]
        [Range(1,10, ErrorMessage = "Rating must be between 1 and 10")]
        public int Rating { get; set; }
    }
}