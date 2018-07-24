using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office
{
    public class Person
    {

        public event Enter OnEnter;
        public event Exit OnExit;

        public string name;

        public Person(string set)
        {
            name = set;
        }

        public void Coming(TimeSpan time)
        {
            this.OnEnter?.Invoke(this, time);

            Console.WriteLine("\n");
        }
        

        public void Leave()
        {
            if (this.OnExit != null)
            {
                this.OnExit(this);
                
            }
        }

        public void SayHello(Person ds1, TimeSpan time)
        {
            Console.WriteLine("{0}, {1} - say {2}", CheckTime(time), ds1.name, this.name);
        }

        public string CheckTime(TimeSpan time)
        {
            
            if (time.Hours < 12)
            {
                return "Good morning";
            }
            if ((time.Hours >= 12) && (time.Hours <= 17))
            {
                return "Good afternoon";
            }
            if (time.Hours > 17)
            {
                return "Good evening";
            }
            return "Hello";
        }

        public void SayGoodBay(Person pr)
        {
            Console.WriteLine("Good bay, {0}-say {1}", pr.name, this.name);
        }
    }
}
