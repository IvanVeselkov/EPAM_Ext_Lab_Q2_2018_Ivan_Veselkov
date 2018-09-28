using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADO.NET.Models;

namespace TestingKnowLedgeVIS.Models
{
    public class IndexViewModel
    {
        public IEnumerable<TestViewModel> Tests { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}