using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Delegates
{
    //1. declare a delegate
    delegate void DelArea(double r);

    delegate void BindUp(DateTime dt);
    class Program
    {
        public static event BindUp Callback = null;

        static void ShowDate(DateTime date)
        {
            Console.WriteLine(date.ToLongDateString());
        }
        static void CalCircleArea(double radius) {
            Console.WriteLine(3.14 * radius * radius);
        }
        static void CalSquareArea(double side)
        {
            Console.WriteLine(side * side);
        }
        static void Main(string[] args)
        {
            //instantiate delegate
            // DelArea delArea =new DelArea(CalCircleArea);
            //delArea += CalSquareArea;
            //Invoke  
            //delArea.Invoke(5);
            // delArea -= CalCircleArea;
            //delArea.Invoke(10);
            //Anonymous methods 
         
            //DelArea delArea1 = delegate(double radius)
            //    {
            //        Console.WriteLine(radius*radius);
            //    };
            //delArea1(20);
            // DelArea delArea2 = r => Console.WriteLine(r * r);
            //delArea2(5);
            //lambda Expression => Shorthand for anonymous methods
            Func<double, double> calSqArea = r => r * r;
           // var res= calSqArea(10);
           // Console.WriteLine(res);
            Action<double> calCircleArea = r => Console.WriteLine(3.14*r*r);
           // calCircleArea(4);
            List<int> scores = new List<int> { 30, 25, 45, 78, 65, 90 };
            //Query Syntax
            var data = from score in scores
                       where score == 45
                       //orderby score descending 
                       select score;
            //Method Syntax
            var data1 = scores.Find(x=>x==30);
            //Console.WriteLine(data1);
            //foreach (var item in data1)
            //{
            //    Console.WriteLine(item);
            //}
            Callback += ShowDate;//subscribing to event handlers
            Callback.Invoke(DateTime.Now);
        }
    }
}
