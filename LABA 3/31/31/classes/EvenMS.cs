using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.classes
{/// <summary>
/// задание 10
/// </summary>
    class EvenMS
    {
        public const int N = 10;
        public int[,] mass = new int[N, N];

        public EvenMS()
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    mass[i,j] = rnd.Next(-100, 100);
                }
            }
        }

        public void GetMASS()
        {
            Console.WriteLine("MASSIVE-----> ");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(mass[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void SumEvenElem()
        {
            Console.WriteLine("SUMMA EVEN ELEMENT OF MASSIVE-----> ");
            int sum = 0;
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    if((i+j)%2==0)
                    {
                        sum += mass[i, j];
                    }
                }
            }
            Console.WriteLine(sum);
        }

        public void SolutionSEEM()
        {
            GetMASS();
            SumEvenElem();
        }
    }
}
