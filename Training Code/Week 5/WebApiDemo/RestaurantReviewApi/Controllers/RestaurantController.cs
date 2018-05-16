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
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.Accepted, restaurants) ;
        }
        public IHttpActionResult Get(int? id)
        {
            if (id!=null || id!=0)
            {
                var restaurant = restaurants.Find(x => x.Id == id);
                if (restaurant!=null)
                {
                    return Ok(restaurant);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest("Please Pass the id to search for the restaurant"); 
        }
        public void Post([FromBody]Restaurant value)
        {
            restaurants.Add(value);
        }
        public void Put(int id, [FromBody]Restaurant value)
        {
            restaurants.Insert(id,value);
        }  
        public void Delete(int id)
        {
            restaurants.RemoveAt(id);
        }
    }
}
