using System;

namespace RestaurantServiceConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestaurantServiceReference.RestaurantServiceClient();
            var results = client.GetAll();
            Console.WriteLine("{");
            foreach (var result in results)
            {
                Console.WriteLine($"\t{result.Id}, {result.Name}, {result.Address}, {result.Url}, {result.Phone}");
            }
            Console.WriteLine("}");
            client.Close();
            Console.ReadKey();
        }
    }
}
