using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions1
{
    public static class SumArr
    {
        public static int Sum(this int[] arr)
        {
            int sum = 0;
            foreach(int y in arr)
            {
                sum += y;
            }
            return sum;
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] arr = { 1, 43, 1, 5, 3, 1, 2, 45 };//sum = 101
            Console.WriteLine("Sum = {0}", arr.Sum());
        }
    }
}
