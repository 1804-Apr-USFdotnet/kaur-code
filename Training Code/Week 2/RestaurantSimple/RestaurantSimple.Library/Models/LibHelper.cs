using RestaurantSimple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimple.Library.Models
{
    public class LibHelper
    {
        public IEnumerable<Restaurant> GetRestaurants()
        {
            IEnumerable<Restaurant> result;
            using (var db = new RestaurantDBEntities())
            {
                var dataList = db.Restaurants.ToList();
                result = dataList.Select(x => DataToLibrary(x)).ToList();
            }
            return result;
        }

        public void AddRestaurant(Restaurant item)
        {
            using (var db = new RestaurantDBEntities())
            {
                db.Restaurants.Add(LibraryToData(item));
                db.SaveChanges();
            }
        }

        // mapping

        public static Restaurant DataToLibrary(Data.Restaurant dataModel)
        {
            var libModel = new Restaurant()
            {
                Name = dataModel.Name
            };
            return libModel;
        }

        public static Data.Restaurant LibraryToData(Restaurant libModel)
        {
            var dataModel = new Data.Restaurant()
            {
                Name = libModel.Name
            };
            return dataModel;
        }
    }
}
