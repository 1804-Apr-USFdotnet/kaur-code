using System;
using System.Linq;

namespace AdvDAL
{
    public class Class1
    {
        public void ShowCustomers()
        {
            TSQLEntities db = new TSQLEntities();
            var customers = db.Customers.Where(x => x.custid == 6);

        }
    }
}
