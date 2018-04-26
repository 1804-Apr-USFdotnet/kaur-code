using System;
using ExtensionMethodDemo;

namespace ConsumeCalculater
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculater calculater = new Calculater();
            Console.WriteLine(calculater.Add(12, 45, 78, 9));
            Console.WriteLine(calculater.Multiply(12,45,78,8));
        }
    }

    public static class ExtendCalculater// put method to be extended in a static class
    {
        public static int Multiply(this Calculater calculater,  params int[] data)// this followed by the class to be extended
        {
            int temp = 1;
            foreach (var item in data)
            {
                temp *= item;
            }
           return temp;

        }
    }
}
