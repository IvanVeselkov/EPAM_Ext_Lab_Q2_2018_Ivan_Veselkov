using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office
{
    class Office
    {
        public List<Person> workers;

        public Office()
        {
            workers = new List<Person>();
        }

        public void CameIn(Person another,TimeSpan time)
        {
            Console.WriteLine("[{0} came to the office in {1}]", another.name, time);
            foreach (var p in this.workers)
            {
                another.OnEnter += p.SayHello;
                another.OnExit += p.SayGoodBay;
                p.OnExit += another.SayGoodBay;
            }

            workers.Add(another);

            another.Coming(time);
        }
        public void LeaveOffice(Person another)
        {
            Console.WriteLine("[{0} leave office]", another.name);
            another.Leave();
            foreach (var p in this.workers)
            {
                p.OnEnter -= another.SayHello;
                p.OnExit -= another.SayGoodBay;
            }

            this.workers.Remove(another);
        }
    }
}
