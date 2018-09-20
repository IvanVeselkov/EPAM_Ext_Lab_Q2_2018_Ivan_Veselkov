using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADO.NET.Models;

namespace TestingKnowLedgeVIS.Models
{
    public class UserEditModel
    {
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPasswd { get; set; }
        public Role UserRole { get; set; }
    }
}