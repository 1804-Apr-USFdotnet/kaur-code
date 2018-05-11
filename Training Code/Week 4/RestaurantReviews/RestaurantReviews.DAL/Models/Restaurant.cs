using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReviews.DAL.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string Url { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
