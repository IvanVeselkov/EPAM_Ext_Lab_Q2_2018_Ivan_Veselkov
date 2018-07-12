using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Question
    {
        private int textQuestion;
        private int id_correctValue;

        public Test Test
        {
            get => default(Test);
            set
            {
            }
        }

        public QuestionType QuestionType
        {
            get => default(QuestionType);
            set
            {
            }
        }

        public QuestionVariable QuestionVariable
        {
            get => default(QuestionVariable);
            set
            {
            }
        }
    }
}