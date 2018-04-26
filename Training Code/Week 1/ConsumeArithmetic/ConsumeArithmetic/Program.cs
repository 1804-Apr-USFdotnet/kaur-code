using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arithmatic;

namespace ConsumeArithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            Maths mathObject = new Maths();
            var result = mathObject.add(11, 13);
            Console.WriteLine(result);
        }
    }
}
