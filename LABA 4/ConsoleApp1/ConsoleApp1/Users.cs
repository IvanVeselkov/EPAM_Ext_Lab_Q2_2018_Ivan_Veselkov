using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Users : Registration
    {
        private int id;
        private int nameUs;
        private int passwdUS;

        public Statistic Statistic
        {
            get => default(Statistic);
            set
            {
            }
        }

        public Role Role
        {
            get => default(Role);
            set
            {
            }
        }

        public TestResult TestResult
        {
            get => default(TestResult);
            set
            {
            }
        }

        public void DelUser()
        {
            throw new System.NotImplementedException();
        }

        public void ChangeUsSet()
        {
            throw new System.NotImplementedException();
        }
    }
}