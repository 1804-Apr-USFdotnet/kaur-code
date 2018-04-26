using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOfOOP
{
    class Program
    {
        static void Main(string[] args)
        {/*
            Person p1;
            p1 = new Person("Prabu", "123456789", 25, 123456748.0M);//calling the instance constructor
            p1.Routine(age: 28, name: "Something");*/

            Employee e = new Employee("Nick","123456789",20,100.00M);
            e.CalSalary(12.0M, 13.0M, 5.0M,2.0M);
            /*p1.name = ".Pushpinder Kaur";
            p1._money = 0.0M;// calling setter
            Console.WriteLine(p1._money);//calling getter
            Console.WriteLine(p1.name);*/
            Console.Read();
        }
    }
}
