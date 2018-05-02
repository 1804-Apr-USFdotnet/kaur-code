using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tapas.Web.Models;

namespace Tapas.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        Restaurant restaurant = new Restaurant();

        // GET: Restaurants
        [HttpGet]// default type of Action
        public ActionResult Index()
        {
            return View(restaurant.GetRestaurants());
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int id)
        {
            return View(restaurant.GetRestaurantById(id));
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            try
            {
                restaurant.AddRestaurant(restaurant);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        /*public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var name = collection["name"];
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurants/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurants/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
