using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.classes
{
    /// <summary>
    /// задание 11
    /// Написать программу, которая определяет среднюю длину слова во введенной текстовой строке.
    /// Учесть, что символы пунктуации на длину слов влиять не должны.
    /// Регулярные выражения не использовать. 
    /// И не пытайтесь прописать все ручками. Используйте стандартные методы класса String.
    /// </summary>
    class MiddleWord
    {
        public string text;
        

        public MiddleWord(string arg)
        {
            text = arg;
        }

        public void SolutionMW()
        {
            //DelPunk();
            string[] words = text.Split(new[] { ' ', ',', '.', ';', ':', '<', '>', '/', '!', '"', '\'', '(', ')', '*', '?', '^', '%', '$', '#', '@', '~', '\\' }, StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;
            int i=0;
            foreach (string st in words)
            {
                sum += st.Length;
                i++;
            }

            Console.WriteLine("The average length of a word in a line: {0}", sum/i);
            Console.ReadLine();

        }
    }
}
