using RestaurantReviews.BLL.Interfaces;
using RestaurantReviews.BLL.Models;
using RestaurantReviews.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RestaurantReviews.BLL.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private RestaurantReviewsDbContext _context;

        public RestaurantRepository(RestaurantReviewsDbContext context)
        {
            _context = context;
        }

        public RestaurantRepository() : this(new RestaurantReviewsDbContext()) { }

        public IEnumerable<Models.Restaurant> GetAll()
        {
            var restaurants = _context.Restaurants.Include(x => x.Reviews);
            return Mapper.Map(restaurants);
        }

        public Models.Restaurant GetById(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            return Mapper.Map(restaurant);
        }

        public bool Exists(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            return restaurant != null;
        }

        public void Insert(Models.Restaurant restaurant)
        {
            _context.Restaurants.Add(Mapper.Map(restaurant));
        }

        public void Delete(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            _context.Restaurants.Remove(restaurant);
        }

        public void Update(Models.Restaurant restaurant)
        {
            var oldRestaurant = _context.Restaurants.Find(restaurant.Id);
            _context.Entry(oldRestaurant).CurrentValues.SetValues(restaurant);
        }

        public Models.Review GetReviewById(int id)
        {
            var review = _context.Reviews.Find(id);
            return Mapper.Map(review);
        }
        
        public bool ReviewBelongsToRestaurant(int restaurantId, int reviewId)
        {
            var restaurant = _context.Restaurants.Find(restaurantId);
            return restaurant?.Reviews.Any(x => x.Id == reviewId) ?? false;
        }

        public void InsertReview(int restaurantId, Models.Review review)
        {
            var restaurant = _context.Restaurants.Find(restaurantId);
            restaurant.Reviews.Add(Mapper.Map(review));
        }

        public void DeleteReview(int id)
        {
            var review = _context.Reviews.Find(id);
            _context.Reviews.Remove(review);
        }

        public void UpdateReview(Models.Review review)
        {
            var oldReview = _context.Restaurants.Find(review.Id);
            _context.Entry(oldReview).CurrentValues.SetValues(review);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing) _context.Dispose();
            _disposed = true;
        }

        public void Dispose()
         {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
