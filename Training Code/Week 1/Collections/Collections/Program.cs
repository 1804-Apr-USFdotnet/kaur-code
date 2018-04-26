using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {   
             #region Arrays
            /*  int[] score;//declaration
              score = new int[5];//intialize
              score[0] = 123;
              score[1] = 456;
              //for (int i = 0; i < score.Length; i++)//Length => no. of elements
              //{
              //    Console.WriteLine(score[i]);
              //}
             /* foreach (var item in score)
              {
                  Console.WriteLine(item);
              }*/

            //2d
            /*
            int row=2, col=3;
            int[,] _2dmatrix = new int[row,col];
            //Console.WriteLine(_2dmatrix.Rank);
            //Jagged Arrays: Array of Array
            int[][] ja = new int[3][];
            ja[0] = new int[2] { 12,13};
            ja[1] = new int[5] { 10,15,12,4,6};
            ja[2] = new int[3] { 45,89,98};
            Console.WriteLine($"Jagged Array length :{ja.Length} and Rank: {ja.Rank}");*/
            #endregion

            #region Nongenerics
            ArrayList[] arrayLists = new ArrayList[10];

            //arrayLists[0].Add("Chipotle");
            //arrayLists[0].Add("Tampa, Florida");
            //arrayLists[0].Add(5.5M);
            //arrayLists[0].Add(12345689);


            Stack reviews = new Stack();
            reviews.Push("Good");
            reviews.Push("Spicy");
            
            Queue orders = new Queue();
            orders.Enqueue(1);
            orders.Enqueue(2);

            ArrayList person = new ArrayList();
            person.Add("David");
            person.Add("Fay");
            person.Add(21);
            person.Add("HR");
            person.Add(100.00M);
            var data = "jhj";
            Console.WriteLine(data.GetType());
            dynamic data2;
            //foreach (var item in person)
            //{
            //    Console.WriteLine(item);
            //}
            person.Insert(4,'A');
          //  person.Sort();
            Console.WriteLine("-------------------------------");
            foreach (var item in person)
            {
                Console.WriteLine(item);
            }
            //shift+alt + down key
            Hashtable restaurantsLocation = new Hashtable();
            restaurantsLocation.Add("Reston", "Chipotle");
            restaurantsLocation.Add("Sterling", "Mod's");
            restaurantsLocation.Add("Orlando", "Wendy's");
            restaurantsLocation.Add("Kentucky", "Caraberra's");
            restaurantsLocation.Add("Portland", "Jeff");
            restaurantsLocation.Add("Houston", "Jonny's");
            restaurantsLocation.Add("Miami", "Taco Bell");
            Console.WriteLine("Location       Restaurants");
            foreach (var location in restaurantsLocation.Keys)
            {
                Console.WriteLine($"{location }   {restaurantsLocation[location]}");
            }
            #endregion

            //System.Collections.Generics
            //List<type>, Stack<type> Queue<Type> Dictionary<Type(key), Type(Value)>

            //Concurrent Classes => optional
        }
    }
}
