using System;
using System.Globalization;

namespace StringSort
{

    class Program
    {
        protected static bool needToReOrder(string s1, string s2)
        {
            for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
            }
            return false;
        }

        delegate void Funtion(string[] a);

        static void SortByLength(string[] arrStr)
        {
            for(int j=0;j<arrStr.Length;j++)
            {
                for (int i = 0; i < arrStr.Length - 1; i++)
                {
                    if(arrStr[i].Length==arrStr[i+1].Length)
                    {
                        if (needToReOrder(arrStr[i], arrStr[i + 1]))
                        {
                            string s = arrStr[i];
                            arrStr[i] = arrStr[i + 1];
                            arrStr[ + 1] = s;
                        }
                    }
                    if (arrStr[i].Length > arrStr[i+1].Length)
                    {
                        string str = arrStr[i];
                        arrStr[i] = arrStr[i + 1];
                        arrStr[i + 1] = str;
                    }
                }
            }
           
        }

        static void Main(string[] args)
        {

            string[] arrStr = { "asd", "asdf", "cvcvx", "asd", "fds" };
            
           

            Funtion funk1 = new Funtion(SortByLength);

            funk1(arrStr);
                   
            foreach(string s in arrStr)
            {
                Console.WriteLine(s);
            }


            Console.ReadKey();
        }
    }
}
