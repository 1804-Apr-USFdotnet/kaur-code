using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapas.DataLayer.Models;

namespace Tapas.Web.Tests.Models
{
    public class testContext : IDbContext
    {
       static List<Restaurant> restaurants = new List<Restaurant>() {
            new Restaurant(){Id=1,Name="Rest1",City="Reston"},
            new Restaurant(){Id=2,Name="Rest2",City="Reston"},
            new Restaurant(){Id=3,Name="Rest3",City="Reston"}          
        };

        Restaurant restaurant1 = new Restaurant() { Id = 4, Name = "Rest3", City = "Reston" };
        public int SaveChanges()
        {
            restaurants.Add(restaurant1);
            return 1;
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
