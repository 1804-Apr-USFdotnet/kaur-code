using System.Collections.Generic;
using System.Linq;

namespace RestaurantReviews.PL.Models
{
    public static class Mapper
    {
        public static IEnumerable<Restaurant> Map(IEnumerable<BLL.Models.Restaurant> source)
        {
            return source.Select(x => Map(x));
        }

        public static Restaurant Map(BLL.Models.Restaurant source)
        {
            return new Restaurant()
            {
                Id = source.Id,
                Name = source.Name,
                Rating = source.Rating,
                Address = source.Address,
                Url = source.Url,
                Phone = source.Phone,
                Reviews = source.Reviews != null ? Map(source.Reviews).ToList() : null
            };
        }

        public static IEnumerable<BLL.Models.Restaurant> Map(IEnumerable<Restaurant> source)
        {
            return source.Select(x => Map(x));
        }

        public static BLL.Models.Restaurant Map(Restaurant source)
        {
            return new BLL.Models.Restaurant()
            {
                Id = source.Id,
                Name = source.Name,
                Address = source.Address,
                Url = source.Url,
                Phone = source.Phone,
                Reviews = source.Reviews != null ? Map(source.Reviews).ToList() : null
            };
        }

        public static IEnumerable<Review> Map(IEnumerable<BLL.Models.Review> source)
        {
            return source.Select(x => Map(x));
        }

        public static Review Map(BLL.Models.Review source)
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

        public static IEnumerable<BLL.Models.Review> Map(IEnumerable<Review> source)
        {
            return source.Select(x => Map(x));
        }

        public static BLL.Models.Review Map(Review source)
        {
            return new BLL.Models.Review()
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