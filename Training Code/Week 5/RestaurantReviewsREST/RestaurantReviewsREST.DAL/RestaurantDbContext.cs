namespace RestaurantReviewsREST.DAL
{
    using System.Data.Entity;

    public partial class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext()
            : base("name=RestaurantReviewsDB")
        {
        }

        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
