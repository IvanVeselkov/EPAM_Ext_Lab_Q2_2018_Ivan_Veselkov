using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.classes
{/// <summary>
/// задание 6
/// </summary>
    class TextSelection
    {
        public bool bold;
        public bool italic;
        public bool underline;
        int numberSEL;

        public TextSelection()
        {
            bold = false;
            italic = false;
            underline = false;
        }

        public void InputSelection()
        {
            Console.WriteLine("Enter:\n" +
                   "       1:Bold\n" +
                   "       2:Italic\n" +
                   "       3:Underline\n" +
                   "      -1:Exit\n");
            numberSEL = int.Parse(Console.ReadLine());
        }

        public void CheckSelection()
        {
            Console.Write("Inscription parameters: ");
            if((this.bold==false)&&(this.italic == false) && (this.underline == false))//000 //todo pn а вот это залет)
            {
                Console.WriteLine("None");
            }
            if ((this.bold == false) && (this.italic == false) && (this.underline == true))//001
            {
                Console.WriteLine("Underline");
            }
            if ((this.bold == false) && (this.italic == true) && (this.underline == false))//010
            {
                Console.WriteLine("Italic");
            }
            if ((this.bold == false) && (this.italic == true) && (this.underline == true))//011
            {
                Console.WriteLine("Italic, Underline");
            }
            if ((this.bold == true) && (this.italic == false) && (this.underline == false))//100
            {
                Console.WriteLine("Bold");
            }
            if ((this.bold ==true) && (this.italic == false) && (this.underline == true))//101
            {
                Console.WriteLine("Bold, Underline");
            }
            if ((this.bold == true) && (this.italic == true) && (this.underline == false))//110
            {
                Console.WriteLine("Bold, Italic");
            }
            if ((this.bold == true) && (this.italic == true) && (this.underline == true))//111
            {
                Console.WriteLine("Bold, Italic, Underline");
            }
        }

        public void SolutionTS()
        {
            do
            {
                this.CheckSelection();
                this.InputSelection();


                switch (numberSEL)
                {
                    case 1:
                        if (this.bold == false)//todo pn можно одной строкой записать
                            this.bold = true;
                        else
                            this.bold = false;
                        break;
                    case 2:
                        if (this.italic == false)
                            this.italic = true;
                        else
                            this.italic = false;
                        break;
                    case 3:
                        if (this.underline == false)
                            this.underline = true;
                        else
                            this.underline = false;
                        break;
                    case -1:
                        break;
                    default:
                        this.InputSelection();
                        break;
                }

            } while (numberSEL != -1);//todo хардкод
		}
    }
}
