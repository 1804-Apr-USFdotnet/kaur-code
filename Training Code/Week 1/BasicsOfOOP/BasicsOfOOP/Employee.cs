using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOfOOP
{
    partial class Person
    {
        public void DoSomething()
        {
            Console.WriteLine("Part 2");
        }
    }
    class Employee: Person
    {
        public decimal hra,ta,tax,fa,basic;

        public Employee(string name, string ssn, int age, decimal money):base(name,ssn,age,1000.00M)
        {
           // Person p1 = new Person("abc","aad",23,10.00M);
            Console.WriteLine($"{name}\n{ssn}\n{age}\n{money}");
        }
        public override string Routine(string name, int age, string routine = "Mid Level")
        {
            return "overrided";
        }
        // number of parameters
        public decimal CalSalary(decimal basic, decimal hra, decimal tax) {
            return basic + hra-tax;
        } 
        public decimal CalSalary(decimal basic, decimal hra, decimal tax, decimal fa)
        {
            return basic + fa+hra - tax;
        }
        public decimal CalSalary(decimal basic, decimal hra, decimal tax,decimal ta,decimal fa)
        {
            return basic +ta+fa+ hra - tax;
        }
        //datatype of the paramenters
        public int CalSalary(int basic, int hra, float tax)
        {
            return basic + hra - Convert.ToInt32(tax);
        }
        // sequence of parameters
        public int CalSalary(float tax,int basic, int hra)
        {
            return basic + hra - Convert.ToInt32(tax);
        }
    }
}
