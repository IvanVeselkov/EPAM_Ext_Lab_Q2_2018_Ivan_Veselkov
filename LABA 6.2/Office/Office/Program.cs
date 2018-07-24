using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office
{
    public delegate void Enter(Person a,TimeSpan time);
    public delegate void Exit(Person a);
    class Program
    {
        

        static void Main(string[] args)
        {
            Office of = new Office();
            Person john = new Person("John");
            Person frank = new Person("Frank");
            Person bob = new Person("Bob");

            of.CameIn(john, new TimeSpan(10,00,00));
            of.CameIn(frank, new TimeSpan(12,30,00));
            of.CameIn(bob, new TimeSpan(18,00,00));

            of.LeaveOffice(john);
            of.LeaveOffice(frank);
            of.LeaveOffice(bob);

            Console.ReadKey();
        }
    }
}
