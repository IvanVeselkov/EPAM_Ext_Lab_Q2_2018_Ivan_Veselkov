using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingKnowLedgeVIS.Models
{
    public class AnswerViewModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int Correct { get; set; }
        public int QuestID { get; set; }
    }
}