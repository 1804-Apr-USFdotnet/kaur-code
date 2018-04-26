using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOfOOP
{
   partial class Person
    {
        protected string ssn;
        public string name;
        public int age;
        private decimal money;
        //properties: Smart fields => prop
        public decimal _money {
            get {
                return money;
            }
            set
            {
                money = value;
            }
        }
        public int  hairColor{ get; set; }//auto properties

        //Constructors: Special Member methods
        public Person()//default Constructor
        {
            ssn = "7896545632";
            name = "Fred";
            age = 21;
            money = 10000000.00M;
            hairColor = 000;
            Console.WriteLine("Default Constructor of Person Name: {0} ssn: {1} age: {2} money: {3}",name,ssn,age,money);
        }
        //ctor
        public Person(string name, string ssn, int age, decimal money)// parameterised
        {
            this.name = name;
            this.age = age;
            this.ssn = ssn;
            this.money = money;
            Console.WriteLine("Parametrised Constructor of Person Name: {0} ssn: {1} age: {2} money: {3}", name, ssn, age, money);
        }
        public virtual string Routine(string name, int age, string routine="Mid Level")
        {
            if (age > 20 && age < 24)
            {
                routine = "entry level";
                Console.WriteLine($"{name} has entry level routine {routine}");
                return routine;
            }
            else
            {
                routine = "mid  level";
                Console.WriteLine($"{name} has mid level routine {routine}");
                return routine;
            }
           
        }
     
    }
}
