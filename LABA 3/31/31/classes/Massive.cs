using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.classes
{/// <summary>
/// задание 7
/// </summary>
    class Massive
    {
        public const int N = 10;
        public int[] mass = new int[N];

        public Massive()
        {
            Random rnd = new Random();
            for(int i=0;i<N;i++)
            {
                mass[i] = rnd.Next(-100, 100);
            }
        }

        public void GetMASS()
        {
            Console.WriteLine("MASSIVE-----> ");
            for(int i=0;i<N;i++)
            {
                Console.Write(mass[i] + " ");
            }
            Console.WriteLine();
        }

        public void FindMIN()
        {
            Console.WriteLine("MINIMUN-----> ");
            int min = 200;
            for(int i=0;i<N;i++)
            {
                if(mass[i]<min)
                {
                    min = mass[i];
                }
            }
            Console.WriteLine(min);
        }

        public void FindMAX()
        {
            Console.WriteLine("MAXIMUM----->");
            int max = -200;
            for (int i = 0; i < N; i++)
            {
                if (mass[i] >max)
                {
                    max= mass[i];
                }
            }
            Console.WriteLine(max);
        }

        public void SortMass()
        {
            Console.WriteLine("SORT MASSIVE----->");
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N-1;j++)
                {
                    if(mass[j]>mass[j+1])
                    {
                        int k = mass[j];
                        mass[j] = mass[j + 1];
                        mass[j + 1] = k;
                    }
                }
            }
            for(int i=0;i<N;i++)
            {
                Console.Write(mass[i] + " ");
            }
            Console.WriteLine();
        }

        public void SolutionMS()
        {
            GetMASS();
            Console.WriteLine();
            FindMAX();
            Console.WriteLine();
            FindMIN();
            Console.WriteLine();
            SortMass();
            Console.WriteLine();
        }
    }
}
