using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.classes
{/// <summary>
/// четвертое задание
/// </summary>
    class Triangles
    {
        public void solutionTR()
        {
            int nBegin = int.Parse(Console.ReadLine());
            int length = nBegin * 2 - 1;
            int midIn = (length / 2) + 1;
            for (int l=0;l<nBegin;l++)
            {
                for (int i = 0; i < l+1; i++)
                {
                    for (int j = 0; j < length + 1; j++)
                    {
                        if ((j >= midIn - i) && (j <= midIn + i))
                        {
                            Console.Write('*');
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
