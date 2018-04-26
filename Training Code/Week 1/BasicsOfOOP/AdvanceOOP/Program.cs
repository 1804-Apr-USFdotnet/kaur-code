using System;
namespace AdvanceOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Credit credit = new Credit();
            IAmex amex = new Credit();//upcasting
            IBoa boa = new Credit();
            string offer=amex.Offer(450, 4000);
            Console.WriteLine($"Offer from Amex {offer}");
            string offerBOA = boa.Offer(650, 4000);
            Console.WriteLine($"Offer from BOA {offerBOA}");
        }
    }
}
