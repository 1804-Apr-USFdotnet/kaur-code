using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TsqlCrud crud = new TsqlCrud();
            var customers=  crud.ShowCustomers();
            foreach (var cust in customers)
            {
                Console.WriteLine(cust.custid+"||"+cust.contactname);
            }
        }
    }
}
