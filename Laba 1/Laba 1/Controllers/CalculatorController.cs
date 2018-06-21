using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laba_1.Controllers
{
    public class CalculatorController : Controller
    {
        public string story;
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
                result = "Incorrect arguments";


            switch (math)
            {
                case "+":
                    result = (a + b).ToString();
                    break;
                case "-":
                    result = (a - b).ToString();
                    break;
                case "*":
                    result = (a * b).ToString();
                    break;
                case "/":
                    if (b != 0)
                        result = (a / b).ToString();
                    else
                        result = "exception division by zero";
                    break;
            }
            DateTime loctime = DateTime.Now;
            vdata.time = loctime.ToString();
            
            vdata.result = result;
            vdata.story = vdata.story + "\n" + vdata.time + " ->::   " + vdata.arg1 + vdata.math + vdata.arg2 + "=" + vdata.result;
            return View("Calc",vdata);
        }//*/

    }
}