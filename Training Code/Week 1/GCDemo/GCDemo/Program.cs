using System;

namespace GCDemo
{
    class Person
    {
        string name;
        public Person()
        {
            name = "Sheila";
        }
    }
    class Employee:IDisposable
    {
        public bool isDisposed = false;
        public string name;
        public Employee(string name)
        {
            this.name = name;
        }
        ~Employee()
        {
            Dispose(false);
        }
        public void PaySalary()
        {
            if (!isDisposed)
            {
                Console.WriteLine("Employee {0} account is active.", name);
            }
            else
            {
                throw new ObjectDisposedException("Employee already disposed.");
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                isDisposed = true;
                Console.WriteLine("Employee object disposed.");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("Ravi");
            emp.name = "carol";
           // emp.Dispose();
            Console.WriteLine("Memory used before collection:  {0:N0}", GC.GetTotalMemory(false));
            emp = null;
            GC.Collect();
            Console.WriteLine("Memory used after collection:   {0:N0}", GC.GetTotalMemory(true));
        }
    }
}
