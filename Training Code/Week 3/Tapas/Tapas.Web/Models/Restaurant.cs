using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Tapas.DataLayer;

namespace Tapas.Web.Models
{
    public class RestRevViewModel
    {
        public Reviews reviews { get; set; }
        public Restaurant restaurant { get; set; }

    }
   public class Reviews
    {
        public int Id { get; set; }
        public Restaurant Restaurant { get; set; }
    }
    public class Restaurant
    {
        private TapasContext _db = new TapasContext();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Street1 { get; set; }
        public bool Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public Reviews reviews { get; set; }
        public string Address
        {
            get
            {
                return Street1 + " ," + Street2 + " ," + City + " ," + State + " ," + Country + " ," + Zipcode;
            }

        }
        //static List<Restaurant> restaurants = new List<Restaurant>() {
        //        new Restaurant(){Id=1,Street1="Elden st", Street2=true, Name="Paradise", City="Reston", State="VA",Country="US",Zipcode="10130"},
        //        new Restaurant(){Id=2,Street1="Elden st", Street2=true, Name="Wendy's", City="Reston", State="VA",Country="US",Zipcode="20130 "},
        //        new Restaurant(){Id=3,Street1="Elden st", Street2=true, Name="Mod's", City="Reston", State="VA",Country="US",Zipcode="20130 " }
        //    };
        public IEnumerable<Restaurant> GetRestaurants()
        {
            var rests = _db.Restaurants.ToList();
            var result = rests.Select(x => ToWeb(x));
            return result;
        }
        public Restaurant GetRestaurantById(int id)
        {
            return ToWeb(_db.Restaurants.Where(x => x.Id==id).FirstOrDefault());
        }
        public void AddRestaurant(Restaurant restaurant)
        {
            _db.Restaurants.Add(ToData(restaurant));
            _db.SaveChanges();
            Debug.Write("Added 1 Restaurant");
        }


        // comment
        public static Restaurant ToWeb(DataLayer.Models.Restaurant dataRestaurant)
        {
            var webRestaurant = new Restaurant()
            {
                Id = dataRestaurant.Id,
                Name = dataRestaurant.Name,
                Street1 = dataRestaurant.Street1,
                Street2 = (dataRestaurant.Street2.Length > 0),
                City = dataRestaurant.City,
                State = dataRestaurant.State,
                Country = dataRestaurant.Country,
                Zipcode = dataRestaurant.Zipcode
            };
            return webRestaurant;
        }

        public static DataLayer.Models.Restaurant ToData(Restaurant webRestaurant)
        {
            var dataRestaurant = new DataLayer.Models.Restaurant()
            {
                Id = webRestaurant.Id,
                Name = webRestaurant.Name,
                Street1 = webRestaurant.Street1,
                Street2 = webRestaurant.Street2.ToString(),
                City = webRestaurant.City,
                State = webRestaurant.State,
                Country = webRestaurant.Country,
                Zipcode = webRestaurant.Zipcode
            };
            return dataRestaurant;
        }
    }
}