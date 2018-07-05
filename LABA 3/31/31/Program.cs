using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _31.classes;

namespace _31
{
    class Program
    {
        public static int index;

        public void InputTask()
        {
            try
            {
              
                Console.Write("\n" +
                    "Choose a the task number\n");
                Console.Write("1. Square rectangle\n" +
                    "2. Picture first triangle\n" +
                    "3. Picture second triangle\n" +
                    "4. Picture the third triangle\n" +
                    "5. The sum of multiple elements\n" +
                    "6. Text selection\n" +
                    "7. Work with massive\n" +
                    "8. Replacement of positive elements in array\n" +
                    "9. Summa positive elements of massive\n" +
                    "10. Summa even elements of massive\n" +
                    "11. The average length of a word in a line \n" +
                    "12. Doubling letters in the text by letters in a word\n" +
                    "13. Experement speed of work String and StringBuilder\n");
                Console.Write("Input number the task ");
                Console.Write("or input -1 to close  \n number = ");
                index = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Wrong Input");
                this.InputTask();
            }
         }

       

        static void Main(string[] args)
        {
            Console.WriteLine("Hello ma brother\n");
            Program P = new Program();
            P.InputTask();
            

            do
            {
                switch (index)
                {
                    case 1:
                        Console.WriteLine("Task 1");
                        Square Rec = new Square();
                        Rec.solutionSQ();
                        P.InputTask();
                        break;

                    case 2:
                        Console.WriteLine("Task 2");
                        Triangle TR = new Triangle();
                        TR.solutionTR();
                        P.InputTask();
                        break;

                    case 3:
                        Console.WriteLine("Task 3");
                        Triangle2 TR2 = new Triangle2();
                        TR2.solutionTR();
                        P.InputTask();
                        break;

                    case 4:
                        Console.WriteLine("Task 4");
                        Triangles TRS = new Triangles();
                        TRS.solutionTR();
                        P.InputTask();
                        break;

                    case 5:
                        Console.WriteLine("Task 5");
                        SumEl Summ = new SumEl();
                        Summ.solutionSum();
                        P.InputTask();
                        break;

                    case 6:
                        Console.WriteLine("Task 6");
                        TextSelection TS = new TextSelection();
                        TS.SolutionTS();
                        P.InputTask();
                        break;
                    case 7:
                        Console.WriteLine("Task 7");
                        Massive M = new Massive();
                        M.SolutionMS();
                        P.InputTask();
                        break;
                    case 8:
                        Console.WriteLine("Task 8");
                        ThreeDimMS Ms = new ThreeDimMS();
                        Ms.SolutionTM();
                        P.InputTask();
                        break;
                    case 9:
                        Console.WriteLine("Task 9");
                        SumEMASS SMS = new SumEMASS();
                        SMS.SolutionSEM();
                        P.InputTask();
                        break;
                    case 10:
                        Console.WriteLine("Task 10");
                        EvenMS EM = new EvenMS();
                        EM.SolutionSEEM();
                        P.InputTask();
                        break;
                    case 11:
                        Console.WriteLine("Task 11");
                        Console.WriteLine("Enter the str: ");
                        String STR = Console.ReadLine();
                        MiddleWord MW = new MiddleWord(STR);
                        MW.SolutionMW();
                        P.InputTask();
                        break;
                    case 12:
                        Console.WriteLine("Task 12");
                        Console.WriteLine("Enter the text: ");
                        String Text = Console.ReadLine();
                        Console.WriteLine("Enter the word: ");
                        String Word = Console.ReadLine();
                        LetDoub LD = new LetDoub(Text,Word);
                        LD.SolutionLD();
                        P.InputTask();
                        break;
                    case 13:
                        Console.WriteLine("Task 13");
                        Console.WriteLine("Enter number of repetitions N = ");
                        int N = int.Parse(Console.ReadLine());
                        Experement E = new Experement(N);
                        E.SolutionE();
                        P.InputTask();
                        break;
                    default:
                        P.InputTask();
                        
                        break;

                }
            } while (index != -1);//*/
        }  
    }
}
