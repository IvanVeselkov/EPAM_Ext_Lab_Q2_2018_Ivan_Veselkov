
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Mvc;

namespace Number1.Controllers
{

     public class DataHost
     { 
        public List<string> leftList = new List<string>() { "Option1", "Option1" };
        public List<string> rightList = new List<string>() { "Option2", "Option2" };
     }
public class HomeController : Controller
    {
        public List<string> leftList = new List<string>() { "Option1", "Option1" };
        public List<string> rightList = new List<string>() { "Option2", "Option2" };

        public ActionResult Index()
        {
            ViewBag.Left = leftList;
            ViewBag.Right = rightList;
            return View();
        }

        [WebMethod]
        public void SaveToLeftList(string leftArray, string rightArray)
        {
            leftList = JsonConvert.DeserializeObject<List<string>>(leftArray);
            rightList = JsonConvert.DeserializeObject<List<string>>(rightArray);
        }
    }
}