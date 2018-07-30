using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions3
{
  
  
    class Program
    {
        static int[] arr;

        static public int N;

        static void Init(int size)
        {
            arr = new int[size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(-10, 10);
            }
        }

        public delegate int[] FPositive(int[] arr,int N);
        public delegate bool FNegative(int nuber);

        static public int SearchPositive(int[] arr)//на прямую
        {
            int count = 0;
            foreach (int a in arr)
            {
                if (a > 0)
                {
                    count++;
                }
            }
            return count;
        }

        //static public bool 
        static public int SearchPositive(FPositive fp)
        {
            int countPos = 0;
            foreach(int i in fp(arr,N))
            {
                if(i>0)
                {
                    countPos++;
                }
            }
            return countPos;
        }


        static int[] IsPositive(int[] number,int N)
        {

            int count=0;
            for(int i=0;i<N;i++)
            {
                if(number[i]>0)
                {
                    count++;
                }
            }
            int[] arrPos = new int[count];
            int j = 0;
            for (int i = 0; i < N; i++)
            {
                if (number[i] > 0)
                {
                    arrPos[j] = number[i];
                    j++;
                }
            }
            return arrPos;
        }

        static bool IsNegative(int number)
        {
            return (number < 0);
        }

        static int SearchNegative(FNegative FN, int[] arr)
        {
            int countNegative = 0;
            foreach (int i in arr)
            {
                if (FN(i))
                {
                    countNegative++;
                }
            }
            return countNegative;
        }

        
        static void Main(string[] args)
        {
            N = 10;
            Init(N);



            Stopwatch sw = new Stopwatch();

            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine("The search directly\n");
            sw.Reset();
            sw.Start();
            int aNumber1 = SearchPositive(arr);//поиск напрямую; 
            //Console.WriteLine(aNumber1);
            Console.WriteLine("Count positive elemntov in array:{0}\nTime Work:{1}\n",aNumber1,sw.ElapsedMilliseconds);

            Console.WriteLine("The search is passed through the delegate\n");
            sw.Reset();
            sw.Start();
            FPositive Fp = new FPositive(IsPositive);//поиск передаётся через делегат; 
            int aNumber2 = SearchPositive(Fp);
            Console.WriteLine("Count positive elemntov in array:{0}\nTime Work:{1}\n", aNumber2, sw.ElapsedMilliseconds);

            Console.WriteLine("The search is passed through the delegate in the form of an anonymous method\n");
            sw.Reset();
            sw.Start();
            FPositive FP = new FPositive(IsPositive); //поиск передаётся через делегат в виде анонимного метода
            int aNumber3 = SearchPositive(delegate (int[] arr, int N)
            {

                int count = 0;
                for (int i = 0; i < N; i++)
                {
                    if (arr[i] > 0)
                    {
                        count++;
                    }
                }
                int[] arrPos = new int[count];
                int j = 0;
                for (int i = 0; i < N; i++)
                {
                    if (arr[i] > 0)
                    {
                        arrPos[j] = arr[i];
                        j++;
                    }
                }
                return arrPos;
            }
            );

            Console.WriteLine("Count positive elemntov in array:{0}\nTime Work:{1}\n", aNumber3, sw.ElapsedMilliseconds);

            sw.Reset();
            sw.Start();
            FNegative Fn = new FNegative(IsNegative);//поиск передаётся через делегат в виде лямбда-выражения
            int aNumber4 = SearchNegative(number => number < 0, arr);
            Console.WriteLine("Count negative elemntov in array:{0}\nTime Work:{1}\n", aNumber4, sw.ElapsedMilliseconds);

            sw.Reset();
            sw.Start();
            FNegative FN = new FNegative(IsNegative);
            int aNumber5 = (from number in arr
                            where number < 0
                            select number).Count();

            Console.WriteLine("Count negative elemntov in array:{0}\nTime Work:{1}\n", aNumber5, sw.ElapsedMilliseconds);//todo pn опять так же финя)

        }
    }
}
