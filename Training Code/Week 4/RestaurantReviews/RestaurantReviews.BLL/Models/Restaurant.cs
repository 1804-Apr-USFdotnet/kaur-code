using System.Collections.Generic;
using System.Linq;

namespace RestaurantReviews.BLL.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
        public string Phone { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public double Rating => Enumerable.Average(Reviews.Select(x => x.Rating));
    }
}
