using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReviews.DAL.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Range(0, 4)]
        public int Rating { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int RestaurantId { get; set; }
    }
}