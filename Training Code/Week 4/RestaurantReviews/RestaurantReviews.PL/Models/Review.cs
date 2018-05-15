using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReviews.PL.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        [Range(0, 4)]
        public int Rating { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int RestaurantId { get; set; }
    }
}
