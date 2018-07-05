using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.classes
{ /// <summary>
/// пятая лаба
/// </summary>
    class SumEl
    {
        const int N = 1000;

        public void solutionSum()
        {
            int sum = 0;
            for(int i=3;i<N;i++)
            {
                if((i%3==0)||(i%5==0))
                {
                    sum += i;
                }
            }
            Console.WriteLine("the sum of the elements of multiples of 3 and 5 from 0.." + N + " is equal to =" + sum);
        }
    }
}
