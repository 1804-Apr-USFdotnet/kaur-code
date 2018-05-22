using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AuthTest2
{
    public class DataDbContext : IdentityDbContext<IdentityUser>
    {
        public DataDbContext() : base("DataDb")
        {

        }
    }
}