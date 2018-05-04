using MvcTemplatesDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplatesDemo.Controllers
{
    public class RestaurantController : Controller
    {
        private static List<Restaurant> _restaurants = new List<Restaurant>()
        {
            new Restaurant() { Id = 1, Name = "Fred", Rating = 4 },
            new Restaurant() { Id = 2, Name = "Nick", Rating = 5 }
        };

        // GET: Restaurant
        public ActionResult Index()
        {
            return View(_restaurants);
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            return View(_restaurants.First(x => x.Id == id));
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            try
            {
                int newId = _restaurants.Select(x => x.Id).Max() + 1;
                restaurant.Id = newId;
                _restaurants.Add(restaurant);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Restaurant newRestaurant)
        {
            try
            {
                var oldRestaurant = _restaurants.First(x => x.Id == id);

                _restaurants.Remove(oldRestaurant);
                newRestaurant.Id = oldRestaurant.Id;
                _restaurants.Add(newRestaurant);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var restaurant = _restaurants.First(x => x.Id == id);
                _restaurants.Remove(restaurant);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
