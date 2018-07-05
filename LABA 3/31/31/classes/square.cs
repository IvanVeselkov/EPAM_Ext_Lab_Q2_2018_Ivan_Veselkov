using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.classes
{/// <summary>
/// первое задание
/// </summary>
    class Square
    {
        public double a;
        public double b;
        public double S;
        
        public Square()
        {
            a = 0;
            b = 0;
            S = 0;
        }

        public Square(double arg1,double arg2)
        {
            a = arg1;
            b = arg2;
            S = 0;
        }

        public double prodSQ()
        {
            return a * b;
        }
        
        public bool checkEl()
        {
            if((a<=0)||(b<=0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void solutionSQ()
        {
            Console.WriteLine("Enter length and width of rectangle ");
            do
            {
                Console.Write("Enter length a = ");
                this.a = double.Parse(Console.ReadLine());
                Console.Write("Enter width b = ");
                this.b = double.Parse(Console.ReadLine());
            } while (!this.checkEl());

            Console.WriteLine("Square Rectangle = " + this.prodSQ());
        }
    }

}
