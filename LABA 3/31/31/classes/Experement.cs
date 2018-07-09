using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace _31.classes
{/// <summary>
/// 13 лаба
/// </summary>
    class Experement
    {
        public string log;
        public int N;

        public Experement(int a)
        {
            log = "";
            N = a;
        }

        public void SetLog()
        {
            using (StreamWriter outputFile = new StreamWriter(@"F:\учеба\epam\LABA 3\31\31\classes\ExperementLog\LOG.txt"))//todo pn хардкод + упало на этой строке.
            {
                 outputFile.WriteLine(log);
            }
        }

        public void SolutionE()
        {
            string str = "";
            StringBuilder sb = new StringBuilder();
            Stopwatch strWatch = new Stopwatch();
            Stopwatch sbWatch = new Stopwatch();

            strWatch.Start();
            for (int i = 0; i < N; i++)
            {
                str += "*";//todo pn хардкод
			}
            strWatch.Stop();
            sbWatch.Start();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");//todo pn хардкод
			}
            sbWatch.Stop();

           
            log = "For H = " + N+" . RunTime String = "+strWatch.Elapsed+" . RunTime StringBuilder = "+sbWatch.Elapsed;//todo pn хардкод
			SetLog();

            Console.WriteLine("RunTime String " + strWatch.Elapsed);//todo pn хардкод
			Console.WriteLine("RunTime StringBuilber " +sbWatch.Elapsed);
         

        }
    }
}
