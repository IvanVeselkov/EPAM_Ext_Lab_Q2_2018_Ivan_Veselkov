using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.classes
{/// <summary>
/// третье задание
/// </summary>
    class Triangle2
    {
        public void solutionTR()
        {
            Console.WriteLine("Enter the number of rows");
            int nBegin = int.Parse(Console.ReadLine());
            //значение вводимое
            int length = 2 * nBegin - 1;
            
            int midIn = (length / 2) + 1;
            for(int i=0;i<nBegin; i++)
            {
                for(int j=0;j<length+1;j++)
                {
                    if ((j >= midIn - i)&&(j<=midIn+i))
                    {
                        Console.Write('*');
                    } else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
