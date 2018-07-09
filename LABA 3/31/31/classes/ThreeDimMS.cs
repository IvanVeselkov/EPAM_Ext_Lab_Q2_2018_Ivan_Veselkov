using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.classes
{
    class ThreeDimMS
    {/// <summary>
    /// задание 8
    /// </summary>
        public const int N = 5;
        public int[,,] mass = new int[N, N, N];


        public ThreeDimMS()
        {
            Random rnd = new Random();
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    for(int k=0;k<N;k++)
                    {
                        mass[i,j,k] = rnd.Next(-100, 100);
                    }
                }
            }
        }

        public void GetMAS()
        {
            Console.WriteLine("MASSIVE-------->\n");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        Console.Write(mass[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("-------------------------------");
            }
        }

        public void FindPositive()
        {
            Console.WriteLine("Find positive elements and replace them by 0");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        if(mass[i,j,k]>0)
                        {
                            mass[i, j, k] = 0;
                        }
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        Console.Write(mass[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("-------------------------------");
            }
        }
        

        public void SolutionTM()
        {
            GetMAS();
            FindPositive();
        }

    }
}
