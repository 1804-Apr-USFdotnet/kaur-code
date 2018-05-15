using System;
using ConsumeConversionService.ConversionServiceReference;

namespace ConsumeConversionService
{
    class Program
    {
        static void Main(string[] args)
        {
            ConversionClient client = new ConversionClient();
            var result= client.ConvertCelciusToFahrenheit(32.50M);
            Console.WriteLine("Convert Celsius to Fahrenheit");
            Console.WriteLine($"32.50 C = { result} F");
            Console.WriteLine("Convert Dollar to INR");
           var rupees= client.ConvertUSDToINR(45, 68.20M);
            Console.WriteLine($"$45 = INR {rupees} ");
        }
    }
}
