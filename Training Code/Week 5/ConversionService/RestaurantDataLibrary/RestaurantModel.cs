namespace RestaurantDataLibrary
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RestaurantModel : DbContext
    {
        public RestaurantModel()
            : base("name=RestaurantModel")
        {
        }

        public virtual DbSet<rest> rests { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<rest>()
                .HasMany(e => e.Reviews)
                .WithOptional(e => e.rest)
                .HasForeignKey(e => e.Restaurant_Id);
        }
    }
}
