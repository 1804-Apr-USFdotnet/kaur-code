using AutoMapper;
using RestaurantService.DAL;
using System;
using System.Collections.Generic;

namespace RestaurantService.SL
{
    public class RestaurantService : IRestaurantService, IDisposable
    {
        private readonly RestaurantDbContext _db;
        private readonly IMapper _mapper;

        public RestaurantService()
        {
            _db = new RestaurantDbContext();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DAL.Restaurant, Restaurant>();
            });

            _mapper = config.CreateMapper();
        }

        public Restaurant Get(int id)
        {
            var item = _db.Restaurants.Find(id);
            return _mapper.Map<Restaurant>(item);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _mapper.Map<IEnumerable<Restaurant>>(_db.Restaurants);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null) _db.Dispose();
            }
        }
    }
}
