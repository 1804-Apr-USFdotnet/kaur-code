using System;
using System.Collections.Generic;
using RestaurantDataLibrary;
using System.Linq;
using System.Text;

namespace ConversionProvider
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Conversion : IConversion
    {
        RestaurantModel db = new RestaurantModel();
        Restaurant restaurant = new Restaurant();
        List<Restaurant> restaurants = new List<Restaurant>();
        /*public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }*/
        public decimal ConvertUSDToINR(int units, decimal currentRate)
        {
            return units * currentRate;
        }
        public decimal ConvertINRToUSD(int units, decimal currentRate)
        {
            return units/currentRate;
        }
        public decimal ConvertCelciusToFahrenheit(decimal celcius)
        {
            return (1.8M * celcius) + 32.0M;
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            var result= db.rests.ToList();
            foreach (var r in result)
            {
               var resultR= Mapper.restToRestaurant(r, restaurant);
                restaurants.Add(resultR);
            }
            return restaurants;
        }

        public rest GetRestaurantById(int id)
        {
            return db.rests.Find(id);
        }
    }
    static class Mapper
    {
        public static Restaurant restToRestaurant(rest rest, Restaurant restaurant)
        {
            StringBuilder address = new StringBuilder();
            if (rest != null)
            {
                restaurant.Name = rest.Name;
                address.Append(rest.s1);
                address.Append(rest.s2);
                address.Append(rest.City);
                address.Append(rest.State);
                address.Append(rest.Country);
                address.Append(rest.Zipcode);
                restaurant.Address = address.ToString();
                restaurant.Phone = rest.Phone;
                return restaurant;
            }
            else
                return null;

        }

    }
}
