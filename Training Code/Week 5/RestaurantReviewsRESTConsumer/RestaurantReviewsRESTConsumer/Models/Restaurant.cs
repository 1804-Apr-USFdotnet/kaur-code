using System.ComponentModel.DataAnnotations;

namespace RestaurantReviewsRESTConsumer.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}