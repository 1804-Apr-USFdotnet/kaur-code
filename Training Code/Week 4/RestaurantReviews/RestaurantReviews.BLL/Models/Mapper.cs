using System.Collections.Generic;
using System.Linq;

namespace RestaurantReviews.BLL.Models
{
    public static class Mapper
    {
        public static IEnumerable<Restaurant> Map(IEnumerable<DAL.Models.Restaurant> source)
        {
            return source.Select(x => Map(x));
        }

        public static Restaurant Map(DAL.Models.Restaurant source)
        {
            return new Restaurant()
            {
                Id = source.Id,
                Name = source.Name,
                Address = source.Address,
                Url = source.Url,
                Phone = source.Phone,
                Reviews = source.Reviews != null ? Map(source.Reviews).ToList() : null
            };
        }

        public static IEnumerable<DAL.Models.Restaurant> Map(IEnumerable<Restaurant> source)
        {
            return source.Select(x => Map(x));
        }

        public static DAL.Models.Restaurant Map(Restaurant source)
        {
            return new DAL.Models.Restaurant()
            {
                Id = source.Id,
                Name = source.Name,
                Address = source.Address,
                Url = source.Url,
                Phone = source.Phone,
                Reviews = source.Reviews != null ? Map(source.Reviews).ToList() : null
            };
        }

        public static IEnumerable<Review> Map(IEnumerable<DAL.Models.Review> source)
        {
            return source.Select(x => Map(x));
        }

        public static Review Map(DAL.Models.Review source)
        {
            return new Review()
            {
                Id = source.Id,
                Rating = source.Rating,
                Description = source.Description,
                Author = source.Author,
                Date = source.Date,
                RestaurantId = source.RestaurantId
            };
        }

        public static IEnumerable<DAL.Models.Review> Map(IEnumerable<Review> source)
        {
            return source.Select(x => Map(x));
        }

        public static DAL.Models.Review Map(Review source)
        {
            return new DAL.Models.Review()
            {
                Id = source.Id,
                Rating = source.Rating,
                Description = source.Description,
                Author = source.Author,
                Date = source.Date,
                RestaurantId = source.RestaurantId
            };
        }
    }
}
