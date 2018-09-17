using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class UserViewModel
    {
        public List<UserModel> Users { get; set; } = new List<UserModel>();
    }
}