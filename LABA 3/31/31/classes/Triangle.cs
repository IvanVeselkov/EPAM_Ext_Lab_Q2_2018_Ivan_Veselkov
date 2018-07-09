using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.classes
{/// <summary>
/// второе задание
/// </summary>
    class Triangle
    {
        public void solutionTR()
        {
            Console.WriteLine("Enter the number of rows");
            int n = int.Parse(Console.ReadLine());
            for(int i=0;i<n;i++)
            {
                for(int j=0;j<i+1;j++)
                {
                    Console.Write("*");//todo хардкод
				}
                Console.WriteLine();
            }
        }
    }
}
