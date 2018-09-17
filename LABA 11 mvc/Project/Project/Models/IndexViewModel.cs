using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class IndexViewModel
    {
        public IEnumerable<IndexTestViewModel> Tests { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}