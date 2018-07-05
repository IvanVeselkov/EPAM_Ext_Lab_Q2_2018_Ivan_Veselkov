using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.classes
{/// <summary>
/// задение 9
/// </summary>
    class SumEMASS
    {
        public const int N = 10;
        public int[] mass = new int[N];

        public SumEMASS()
        {
            Random rnd = new Random();
            for(int i=0;i<N; i++)
            {
                mass[i] = rnd.Next(-100, 100);
            }
        }

        public void GetMASS()
        {
            Console.WriteLine("MASSIVE-----> ");
            for (int i = 0; i < N; i++)
            {
                Console.Write(mass[i] + " ");
            }
            Console.WriteLine();
        }

        public void SumPositElMass()
        {
            Console.WriteLine("Summa positive elemetns of massive equals ----->");
            int Summ = 0;
            for(int i=0;i<N;i++)
            {
                if(mass[i]>0)
                {
                    Summ += mass[i];
                }
            }
            Console.WriteLine(Summ);
        }

        public void SolutionSEM()
        {
            Console.WriteLine("\n\n");
            GetMASS();
            SumPositElMass();
            Console.WriteLine("\n\n");
        }
    }
}
