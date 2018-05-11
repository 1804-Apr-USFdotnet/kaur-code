using System;

namespace RestaurantReviews.BLL.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public int RestaurantId { get; set; }
    }
}