using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.classes
{/// <summary>
/// задание 12
/// </summary>
    class LetDoub
    {
        public string text;
        public string word;
        public string final;

        public LetDoub(string arg1,string arg2)
        {
            text = arg1;
            word = arg2;
            final = "";
        }

        public void SolutionLD()
        {
            foreach (char ch in text)
                if (!word.Contains(ch))
                    final += ch;
                else
                {
                    final += ch;
                    final += ch;
                }
            Console.WriteLine("Результат = {0}", final);//todo pn хардкод
		}
    }
}
