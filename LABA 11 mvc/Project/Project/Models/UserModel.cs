using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPasswd { get; set; }
        public Role UserRole { get; set; }
    }
}
