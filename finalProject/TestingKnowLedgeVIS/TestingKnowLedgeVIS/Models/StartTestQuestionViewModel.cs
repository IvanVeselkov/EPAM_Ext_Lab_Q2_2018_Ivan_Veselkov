using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADO.NET.Models;

namespace TestingKnowLedgeVIS.Models
{
    public class StartTestQuestionViewModel
    {
        public List<QuestViewModel> Question { get; set; } = new List<QuestViewModel>();
        public List<AnswerViewModel> Answer { get; set; } = new List<AnswerViewModel>();
        public QuestPageInfo QuestionPageInfo { get; set; }
    }
}