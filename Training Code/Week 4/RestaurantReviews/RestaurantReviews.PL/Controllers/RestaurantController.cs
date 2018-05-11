using NLog;
using RestaurantReviews.BLL.Interfaces;
using RestaurantReviews.BLL.Repositories;
using RestaurantReviews.PL.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace RestaurantReviews.PL.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantRepository _repo;
        private bool _manageRepo;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public RestaurantController(IRestaurantRepository repo, bool manageRepo = false)
        {
            _repo = repo;
            _manageRepo = manageRepo;
        }

        public RestaurantController() : this(new RestaurantRepository(), true) { }

        // GET: Restaurant
        public ActionResult Index()
        {
            try
            {
                var restaurants = _repo.GetAll();
                return View(Mapper.Map(restaurants));
            }
            catch (Exception e)
            {
                _logger.Info(e);
                return View("Error");
            }
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var restaurant = _repo.GetById(id);
                return View(Mapper.Map(restaurant));
            }
            catch (Exception e)
            {
                _logger.Info(e);
                return View("Error");
            }
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Address,Url,Phone")] Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Insert(Mapper.Map(restaurant));
                    _repo.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                _logger.Info(e);
            }
            return View("Error");
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var restaurant = _repo.GetById(id);
                return View(Mapper.Map(restaurant));
            }
            catch (Exception e)
            {
                _logger.Info(e);
                return View("Error");
            }
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind(Include = "Name,Address,Url,Phone")] Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    restaurant.Id = id;
                    _repo.Update(Mapper.Map(restaurant));
                    _repo.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                _logger.Info(e);
            }
            return View("Error");
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var restaurant = _repo.GetById(id);
                return View(Mapper.Map(restaurant));
            }
            catch (Exception e)
            {
                _logger.Info(e);
                return View("Error");
            }
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _repo.Delete(id);
                _repo.Save();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                _logger.Info(e);
                return View("Error");
            }
        }

        // GET: Restaurant/ReviewDetails/5/6
        public ActionResult ReviewDetails(int id, int reviewId)
        {
            try
            {
                var restaurant = _repo.GetById(id);
                var review = restaurant.Reviews.Single(x => x.Id == reviewId);
                _repo.GetReviewById(reviewId);
                return View(Mapper.Map(review));
            }
            catch (Exception e)
            {
                _logger.Info(e);
                return View("Error");
            }
        }

        // GET: Restaurant/AddReview/5
        public ActionResult AddReview(int id)
        {
            try
            {
                if (_repo.Exists(id))
                {
                    var review = new Review()
                    {
                        RestaurantId = id,
                        Date = DateTime.Now
                    };
                    return View(review);
                }
            }
            catch (Exception e)
            {
                _logger.Info(e);
            }
            return View("Error");
        }

        // POST: Restaurant/AddReview/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview(int id, [Bind(Include = "Rating,Description,Author,Date")] Review review)
        {
            try
            {
                if (_repo.Exists(id) && ModelState.IsValid)
                {
                    _repo.InsertReview(id, Mapper.Map(review));
                    _repo.Save();
                    return RedirectToAction("Details", new { id });
                }
            }
            catch (Exception e)
            {
                _logger.Info(e);
            }
            return View("Error");
        }

        // GET: Restaurant/EditReview/5/6
        public ActionResult EditReview(int id, int reviewId)
        {
            try
            {
                if (_repo.Exists(id) && _repo.ReviewBelongsToRestaurant(id, reviewId))
                {
                    var review = _repo.GetReviewById(reviewId);
                    return View(Mapper.Map(review));
                }
            }
            catch (Exception e)
            {
                _logger.Info(e);
            }
            return View("Error");
        }

        // POST: Restaurant/EditReview/5/6
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReview(int id, int reviewId, [Bind(Include = "Rating,Description,Author,Date")] Review review)
        {
            try
            {
                if (_repo.Exists(id) && _repo.ReviewBelongsToRestaurant(id, reviewId) && ModelState.IsValid)
                {
                    review.Id = reviewId;
                    _repo.UpdateReview(Mapper.Map(review));
                    _repo.Save();
                    return RedirectToAction("Details", new { id });
                }
            }
            catch (Exception e)
            {
                _logger.Info(e);
            }
            return View("Error");
        }

        // GET: Restaurant/DeleteReview/5/6
        public ActionResult DeleteReview(int id, int reviewId)
        {
            try
            {
                if (_repo.Exists(id) && _repo.ReviewBelongsToRestaurant(id, reviewId))
                {
                    var review = _repo.GetReviewById(reviewId);
                    return View(Mapper.Map(review));
                }
            }
            catch (Exception e)
            {
                _logger.Info(e);
            }
            return View("Error");
        }

        // POST: Restaurant/DeleteReview/5/6
        [HttpPost]
        public ActionResult DeleteReview(int id, int reviewId, FormCollection collection)
        {
            try
            {
                if (_repo.Exists(id) && _repo.ReviewBelongsToRestaurant(id, reviewId))
                {
                    _repo.DeleteReview(reviewId);
                    _repo.Save();
                    return RedirectToAction("Details", new { id });
                }
            }
            catch (Exception e)
            {
                _logger.Info(e);
            }
            return View("Error");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _manageRepo) _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
