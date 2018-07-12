using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Test
    {
        private int name;
        private int level;
        private int id;
        private int time;

        internal Program Program
        {
            get => default(Program);
            set
            {
            }
        }

        public Statistic Statistic
        {
            get => default(Statistic);
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

        public void SelectTest()
        {
            throw new System.NotImplementedException();
        }
    }
}