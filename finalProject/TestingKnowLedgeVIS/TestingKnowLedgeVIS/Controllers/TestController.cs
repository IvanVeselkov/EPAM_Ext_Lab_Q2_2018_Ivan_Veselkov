using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADO.NET.Models;
using ADO.NET.Repositories;
using AutoMapper;
using TestingKnowLedgeVIS.Models;

namespace TestingKnowLedgeVIS.Controllers
{
    public class TestController : Controller
    {
        TestRepository TestRep = new TestRepository();
        QuestRepository QuestRep = new QuestRepository();
        AnswerRepository AnswerRep = new AnswerRepository();
        // GET: Test
        public ActionResult Index(int page = 1)
        {
            ViewBag.User = User.Identity.Name;
            int pageSize = TestRep.GetCount(); // количество объектов на страницу
            var testsPerPages = TestRep.GetAll();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ADO.NET.Models.Test,TestingKnowLedgeVIS.Models.IndexTestViewModel>());
            var mapper = config.CreateMapper();
            var tests = mapper.Map<List<ADO.NET.Models.Test>, IEnumerable<TestingKnowLedgeVIS.Models.TestViewModel>>(testsPerPages);

            var pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = TestRep.GetCount()};
            var ivm = new IndexViewModel { PageInfo = pageInfo, Tests = tests };
            return View(ivm);
        }

        public ActionResult PreStartTest(int testId)
        {
            return RedirectToAction("TestStart", new { testId });
        }

        public ActionResult TestStart(int testId, int questionId = 1)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ADO.NET.Models.Quest, StartTestQuestionViewModel>());
            var mapper = config.CreateMapper();
            List<QuestViewModel> questions = new List<QuestViewModel>();
            foreach (var item in QuestRep.GetQuestionList(testId))
            {
                QuestViewModel quest = new QuestViewModel();
                quest.ID = item.ID;
                quest.Description = item.Description;
                quest.TestID = item.TestID;
                questions.Add(quest);
            }
            List<AnswerViewModel> answers = new List<AnswerViewModel>();
            foreach (var item in AnswerRep.GetAllWithQ(questionId))
            {
                AnswerViewModel answer = new AnswerViewModel();
                answer.ID = item.ID;
                answer.Description = item.Description;
                answer.Correct = item.Correct;
                answer.QuestID = item.QuestID;
                answers.Add(answer);
            }
            var pageInfo = new QuestPageInfo { TestId = testId, QuestionId = questionId, TotalPages = QuestRep.GetQuestionList(testId).Count };
            var stqvm = new StartTestQuestionViewModel { QuestionPageInfo = pageInfo, Question = questions , Answer = answers};
            return View(stqvm);
        }

        public ActionResult TestCheckAnswer()
        {
            return View();
        }
        public ActionResult TestResult()
        {
            return View();
        }
    }
}