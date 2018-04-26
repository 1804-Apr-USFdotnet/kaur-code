using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Delegates.MoviePlayer;

namespace Delegates
{
    // Subscriber
    class Program
    {
        static void Main(string[] args)
        {
            var player = new MoviePlayer();
            player.CurrentMovie = "Star Wars";

            //player.Finished += DisplayFinishedMessage;
            //player.Finished += (
            //    (name) =>
            //    {
            //        int a = 3;
            //        a += 1;
            //        Console.WriteLine($"finished movie {name}.");
            //    }
            //);

            FinishedHandler handler = ((name) => Console.WriteLine($"finished movie {name}."));

            player.Finished += handler;

            player.Finished += (name) => Console.WriteLine("second handler too!");

            player.Finished -= handler;

            // handler would no longer be called

            player.Finished += handler;

            player.PlayMovie();

            // ////////////////////// LAMBDA EXPRESSIONS WITH LINQ

            var movieNames = new List<string>()
            {
                "Star Wars",
                "Toy Story",
                "Jurassic Park",
                "The Godfather",
                "The Avengers",
                "Cinderella"
            };

            //int maxLength = 0;
            //for (int i = 0; i < movieNames.Count; i++)
            //{
            //    if (movieNames[i].Length > maxLength)
            //    {

            //    }
            //}

            movieNames.Max(movieName => movieName.Length); // returns 13

            // first movie name that starts with a T
            movieNames.First(x => x[0] == 'T');

            // LINQ Language-Integrated Query Language
            // works on any IEnumerable<> or IQueryable<>

            var y = movieNames.Select(x => x[1]).ToList(); // get the second character of each movie name
        }

        static void DisplayFinishedMessage(string name)
        {
            Console.WriteLine($"finished movie {name}.");
        }
    }
}
