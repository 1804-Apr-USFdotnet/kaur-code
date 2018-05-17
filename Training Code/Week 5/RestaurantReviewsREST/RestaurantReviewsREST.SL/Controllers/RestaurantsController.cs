using AutoMapper;
using AutoMapper.QueryableExtensions;
using RestaurantReviewsREST.DAL;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestaurantReviewsREST.SL.Controllers
{
    public class RestaurantsController : ApiController
    {
        private static IConfigurationProvider mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Models.Restaurant, Restaurant>()
                .ForMember(x => x.Reviews, opt => opt.Ignore());
        });

        private readonly RestaurantDbContext db;
        private readonly IMapper mapper;

        public RestaurantsController()
        {
            db = new RestaurantDbContext();
            mapper = mapperConfig.CreateMapper();
        }

        // GET: api/Restaurants
        public IHttpActionResult GetRestaurants()
        {
            try
            {
                IQueryable<Models.Restaurant> restaurants = db.Restaurants.ProjectTo<Models.Restaurant>(mapperConfig);
                return Ok(restaurants);
            }
            catch
            {
                return InternalServerError();
            }
        }

        // GET: api/Restaurants/5
        [ResponseType(typeof(Models.Restaurant))]
        public IHttpActionResult GetRestaurant(int id)
        {
            Restaurant restaurant;
            try
            {
                restaurant = db.Restaurants.Find(id);
            }
            catch
            {
                return InternalServerError();
            }
            if (restaurant == null)
            {
                return NotFound();
            }

            var restaurantSL = mapper.Map<Models.Restaurant>(restaurant);
            return Ok(restaurantSL);
        }

        // PUT: api/Restaurants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestaurant(int id, Models.Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            restaurant.Id = id;

            Restaurant restaurantDAL;
            try
            {
                restaurantDAL = db.Restaurants.Find(id);
            }
            catch
            {
                return InternalServerError();
            }
            if (restaurantDAL == null)
            {
                return NotFound();
            }
            db.Entry(restaurantDAL).CurrentValues.SetValues(restaurant);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch
            {
                return InternalServerError();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Restaurants
        [ResponseType(typeof(Models.Restaurant))]
        public IHttpActionResult PostRestaurant(Models.Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            restaurant.Id = 0;
            var restaurantDAL = mapper.Map<Restaurant>(restaurant);

            db.Restaurants.Add(restaurantDAL);
            try
            {
                db.SaveChanges();
            }
            catch
            {
                return InternalServerError();
            }

            var newRestaurant = mapper.Map<Models.Restaurant>(restaurantDAL);
            return CreatedAtRoute("DefaultApi", new { id = restaurant.Id }, newRestaurant);
        }

        // DELETE: api/Restaurants/5
        [ResponseType(typeof(Models.Restaurant))]
        public IHttpActionResult DeleteRestaurant(int id)
        {
            Restaurant restaurant;
            try
            {
                restaurant = db.Restaurants.Find(id);
            }
            catch
            {
                return InternalServerError();
            }
            if (restaurant == null)
            {
                return NotFound();
            }

            db.Restaurants.Remove(restaurant);
            try
            {
                db.SaveChanges();
            }
            catch
            {
                return InternalServerError();
            }

            var restaurantSL = mapper.Map<Models.Restaurant>(restaurant);
            return Ok(restaurantSL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantExists(int id)
        {
            return db.Restaurants.Any(e => e.Id == id);
        }
    }
}
