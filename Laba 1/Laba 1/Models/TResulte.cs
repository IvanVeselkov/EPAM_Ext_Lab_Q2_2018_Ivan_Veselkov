using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laba_1.Models
{
    public class TResulte
    {
        public string arg1 { get; set; }
        public string arg2 { get; set; }

        public string math { get; set; }
        public string result { get; set; }
        public  List<string> Story { get; set; } = new List<string>();
        public string time { get; set; }
    }

}