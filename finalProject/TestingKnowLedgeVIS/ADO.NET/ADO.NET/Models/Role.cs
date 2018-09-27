using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADO.NET.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string Desc { get; set; }
        public int DescInt { get; set; }
        public void Saver()
        {
            if(DescInt==1)
                Desc = "admin";
            if (DescInt == 2)
                Desc = "user";
        }
        public void Default()
        {
            Desc = "user";
            DescInt = 2;
        }
    }
}