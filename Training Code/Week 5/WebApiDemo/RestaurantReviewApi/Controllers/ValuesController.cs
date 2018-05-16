using RestaurantReviewApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestaurantReviewApi.Controllers
{
    public class RestaurantController : ApiController
    {
        static List<Restaurant> restaurants =new List<Restaurant>() {
             new Restaurant(){ Id=1, Name="Tarek's", Address="NEC, USF, Tampa FL USA,33617 "},
             new Restaurant(){ Id=2, Name="Wendy's", Address="NEC, USF, Tampa FL USA,33617 "},
             new Restaurant(){ Id=3, Name="Chipotle", Address="NEC, USF, Tampa FL USA,33617 "},
             new Restaurant(){ Id=4, Name="WhataBurger", Address="NEC, USF, Tampa FL USA,33617 "},
             new Restaurant(){ Id=5, Name="MeiPizza", Address="NEC, USF, Tampa FL USA,33617 "}
        };
        // GET api/values
        public IEnumerable<Restaurant> Get()
        {
            return restaurants;
        }

        // GET api/values/5
        public Restaurant Get(int id)
        {
            var restaurant = restaurants.Find(x=>x.Id==id);
            return restaurant;
        }

        // POST api/values
        public void Post([FromBody]Restaurant value)
        {
            restaurants.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Restaurant value)
        {
            restaurants.Insert(id,value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            restaurants.RemoveAt(id);
        }
    }
}
