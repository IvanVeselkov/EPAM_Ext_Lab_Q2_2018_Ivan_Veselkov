using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class TestResult
    {
        private string idUser;
        private int idTest;
        private int scores;

        public Test Test
        {
            get => default(Test);
            set
            {
            }
        }

        public Users Users
        {
            get => default(Users);
            set
            {
            }
        }

        public void GetScores()
        {
            throw new System.NotImplementedException();
        }
    }
}