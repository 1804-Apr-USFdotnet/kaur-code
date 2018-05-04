using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Tapas.DataLayer.Models;

namespace Tapas.DataLayer
{
    class MyClass
    {
       
        
        static void Main(string[] args)
        {
            Restaurant restaurant = new Restaurant();
            Console.WriteLine("Creating DB...............");
            TapasContext db = new TapasContext();
            #region AddTestRest
            /* Console.WriteLine("Db Created..............");
             restaurant.Name = "Mod's";
             restaurant.City = "Reston";
             db.Restaurants.Add(restaurant);
             db.SaveChanges();*/
            #endregion

            #region UpdateRest
            var rest=db.Restaurants.Where(x => x.Id == 1).FirstOrDefault();
            rest.State = "VA";
            db.Entry<Restaurant>(rest).State = EntityState.Modified;
            db.SaveChanges();
            Console.WriteLine("Rest Updated.......");
            #endregion
        }
    }
    public class TapasContext:DbContext,IDbContext
    {
        public TapasContext():base("TapasDb")
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public override int SaveChanges()
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("Created").CurrentValue = DateTime.Now;
            });

            var ModifiedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            ModifiedEntities.ForEach(E =>
            {
                E.Property("Modified").CurrentValue = DateTime.Now;
            });
            return base.SaveChanges();  
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
    }
}
