using RestaurantReviews.BLL.Models;
using System;
using System.Collections.Generic;

namespace RestaurantReviews.BLL.Interfaces
{
    public interface IRestaurantRepository : IDisposable
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(int id);
        bool Exists(int id);
        void Insert(Restaurant restaurant);
        void Delete(int id);
        void Update(Restaurant restaurant);
        Review GetReviewById(int id);
        bool ReviewBelongsToRestaurant(int restaurantId, int reviewId);
        void InsertReview(int restaurantId, Review review);
        void DeleteReview(int id);
        void UpdateReview(Review review);
        void Save();
    }
}
