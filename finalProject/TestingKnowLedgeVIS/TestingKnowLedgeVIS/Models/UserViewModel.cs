using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADO.NET.Models;

namespace TestingKnowLedgeVIS.Models
{
    public class UserViewModel
    {
        public List<UserModel> Users { get; set; } = new List<UserModel>();
    }
}