using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
    // Publisher
    public class MoviePlayer
    {
        public string CurrentMovie { get; set; }

        public delegate void FinishedHandler(string name);

        // can use Action and Func generic types, in place of defining your own delegate types.

        // takes three ints, returns void (nothing)
        Action<int, int, int> f = (a, b, c) => Console.WriteLine(a + b + c);

        // takes three ints, returns string
        Func<int, int, int, string> g = (a, b, c) => "abasdfasd";

        public event FinishedHandler Finished;
        //public event Action<string> Finished; // could do it this way too

        public void PlayMovie()
        {
            Thread.Sleep(3000); // wait 3 seconds

            //Console.WriteLine($"finished movie {CurrentMovie}.");
            //Finished(CurrentMovie); // unsafe, might not have any handlers

            if (Finished != null)
            {
                Finished(CurrentMovie); // unsafe, might not have any handlers
            }
        }
    }
}
