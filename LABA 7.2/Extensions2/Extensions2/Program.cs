using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions2
{
    public static class StringCompare
    {/// <summary>
    /// данный метод будет сравнивать строку с целым числом 
    /// если строка это  число целое и положительное ,то оно выводится
    /// иначе выводится -1
    /// </summary>
    /// <param name="str">проверяемая строка</param>
    /// <returns></returns>
    
        public static int Compare(this string str)
        {
            int[] digits = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            char[] digitsCH = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool isnumeric;

            int number = 0;
            if(str[0]!='-')
            {
                for(int i=0;i<str.Length;i++)
                {
                    isnumeric = false;
                    for(int j=0;j<10;j++)
                    {
                        if(str[i]==digitsCH[j])
                        {
                            isnumeric = true;
                            number = Convert.ToInt32(number + digits[j] 
                                * Math.Pow(10f, str.Length - 1f - i));
                            break;
                        }
                    }
                    if(!isnumeric)
                    {
                        return -1;
                    }
                }
            }
            else
            {
                return -1;
            }
            return number;
        }

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            string str = "225";
            Console.WriteLine(str.Compare()) ;
        }
    }
}
