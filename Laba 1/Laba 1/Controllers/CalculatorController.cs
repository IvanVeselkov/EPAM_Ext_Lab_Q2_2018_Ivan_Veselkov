using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laba_1.Controllers
{
    public class CalculatorController : Controller
    {
        
        // GET: Calculator
        

        public ActionResult Calc(string arg1, string arg2, string math)
        {
           
            Laba_1.Models.TResulte vdata = new Models.TResulte()
            {
                arg1 = arg1,
                arg2 = arg2,
                math = math,
            };

            return View(vdata);
        }

        public ActionResult Result(string arg1,string arg2,string math)
        {
            Laba_1.Models.TResulte vdata = new Models.TResulte()
            {
                arg1 = arg1,
                arg2 = arg2,
                math = math,
            };

            decimal a = 0;
            decimal b = 0;
            string result = "";
            if (!decimal.TryParse(arg1, out a) || !decimal.TryParse(arg2, out b))
                result = "Incorrect arguments";//todo pn вынести в ресурсы (.resx)


			switch (math)
            {
                case "+"://todo pn hardcode. нужно вынести в структуру какую-нибудь. Enum, например.
                    result = (Sum(a,b)).ToString();
                    break;
                case "-":
                    result = (Sub(a,b)).ToString();
                    break;
                case "*":
                    result = (Prod(a,b)).ToString();
                    break;
                case "/":
                    if (b != 0)
                        result = (Div(a,b)).ToString();
                    else
                        result = "exception division by zero";//todo pn вынести в ресурсы (.resx)
                    break;
            }
            DateTime loctime = DateTime.Now;
            vdata.time = loctime.ToString();
            
            vdata.result = result;
            vdata.Story.Add("\n" + vdata.time + " ->::   " + vdata.arg1 + vdata.math + vdata.arg2 + "=" + vdata.result);
            return View("Calc",vdata);
        }//*/

        decimal Sum(decimal x,decimal y)
        {
            return x + y;
        }
        decimal Prod(decimal x, decimal y)
        {
            return x * y;//todo pn необработанное исключение: Value was either too large or too small for a Decimal. при достаточно больших значениях переменных.
		}
        decimal Div(decimal x, decimal y)
        {
            return x / y;
        }
        decimal Sub(decimal x, decimal y)
        {
            return x -y;
        }
    }
}