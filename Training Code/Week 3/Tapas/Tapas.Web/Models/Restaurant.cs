using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

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
        static List<Restaurant> restaurants = new List<Restaurant>() {
                new Restaurant(){Id=1,Street1="Elden st", Street2=true, Name="Paradise", City="Reston", State="VA",Country="US",Zipcode="10130"},
                new Restaurant(){Id=2,Street1="Elden st", Street2=true, Name="Wendy's", City="Reston", State="VA",Country="US",Zipcode="20130 "},
                new Restaurant(){Id=3,Street1="Elden st", Street2=true, Name="Mod's", City="Reston", State="VA",Country="US",Zipcode="20130 " }
            };
        public IEnumerable<Restaurant> GetRestaurants()
        {           
            return restaurants;
        }
        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.Where(x=>x.Id==id).FirstOrDefault();
        }
        public void AddRestaurant(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            Debug.Write("Added 1 Restaurant");
        }

    }
}