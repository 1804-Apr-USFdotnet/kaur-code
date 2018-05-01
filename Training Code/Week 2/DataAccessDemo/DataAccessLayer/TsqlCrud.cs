using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TsqlCrud
    {
        TSQLEntities db = new TSQLEntities();
        // Read All Customers
        public IEnumerable<Customer> ShowCustomers()
        {
            return db.Customers.ToList();
        }
    }
}
