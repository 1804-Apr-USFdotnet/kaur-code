using System;
using ArithmaticOperations;// use the custom namespace

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Maths mathsObj = new Maths();
           decimal average= mathsObj.Average(10, 15);
            Console.WriteLine(average);
            Console.WriteLine("Hello David ");
            Console.Read();
        }
    }
}
