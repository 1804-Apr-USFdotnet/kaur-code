using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReviews.PL.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double Rating { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
