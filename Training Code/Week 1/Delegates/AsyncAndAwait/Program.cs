using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            CallLongTask();
            Console.WriteLine("Finished All");
            Console.Read();
        }
        static async void CallLongTask()
        {
            Console.WriteLine("Calling Long Task..........");
            await Task.Run(new Action(LongTask));
            Console.WriteLine("Long Task Called and completed..............");
        }
        static void LongTask()
        {
            Console.WriteLine("Start executing Long Task Method");
            Thread.Sleep(5000);
            Console.WriteLine("Long Task finished");

        }
    }
}
