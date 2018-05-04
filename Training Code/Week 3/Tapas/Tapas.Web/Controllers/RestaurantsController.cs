using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tapas.DataLayer.Models;
using Tapas.DAL.Repositories;
using System.Net;
using Tapas.DataLayer;

namespace Tapas.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        ICrud<Restaurant> crud;
        IDbContext db;
        public RestaurantsController()
        {
            db = new TapasContext();
            crud = new Crud<Restaurant>(db);
        }
        // GET: Restaurants
        [HttpGet]// default type of Action
        public ActionResult Index()
        {
            var rests = crud.Table.ToList();
            return View(rests);
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int id)
        {
            return View(crud.GetById(id));
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }
       // [ChildActionOnly]=> to be called by parent only
        public PartialViewResult  ChildAction()
        {
            return PartialView();
        }

        // POST: Restaurants/Create
        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)// Server side Validations
                {
                    crud.Insert(restaurant);
                    return RedirectToAction("Index");
                }
                else
                    return View(restaurant);
            }               
                // log that it worked
               
            catch
            {
                // log some problem
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
        public ActionResult Edit(int id,Restaurant restaurant)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    crud.Update(restaurant);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(ModelState);
                }
              
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant rest = crud.GetById(id);
            if (rest == null)
            {
                return HttpNotFound();
            }
            return View(rest);
        }

        // POST: Restaurants/Delete/5
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Restaurant rest = crud.GetById(id);
                if (rest!=null)
                {
                    crud.Delete(rest);
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
