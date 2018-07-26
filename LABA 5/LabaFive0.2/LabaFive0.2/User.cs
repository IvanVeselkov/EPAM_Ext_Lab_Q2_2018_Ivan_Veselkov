using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaFive0._2
{
    public class User
    {
        public int id;
        public string name;

        public User()
        {
            id = 0;
            name = "unc";
        }
        public User(int ID, string NAME)
        {
            id = ID;
            name = NAME;
        }
        public User(string NAME)
        {
            id = 0;
            name = NAME;
        }
        public User(int ID)
        {
            id = ID;
            name = null;
        }
    }
}
