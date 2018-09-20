using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestingKnowLedgeVIS.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestStart()
        {
            return View();
        }

        public ActionResult TestCheckAnswer()
        {
            return View();
        }
        public ActionResult TestResult()
        {
            return View();
        }
    }
}