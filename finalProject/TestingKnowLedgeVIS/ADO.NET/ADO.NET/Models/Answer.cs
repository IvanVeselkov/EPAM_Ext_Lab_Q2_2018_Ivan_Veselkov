using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADO.NET.Models
{
    public class Answer
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int Correct { get; set; }
        public int QuestID { get; set; }
    }
}