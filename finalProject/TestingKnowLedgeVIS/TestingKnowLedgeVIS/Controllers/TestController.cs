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
        // GET: Test
        public ActionResult Index(int page = 1)
        {
            ViewBag.User = User.Identity.Name;
            int pageSize = 3; // количество объектов на страницу
            var testsPerPages = TestRep.GetAll();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ADO.NET.Models.Test,TestingKnowLedgeVIS.Models.IndexTestViewModel>());
            var mapper = config.CreateMapper();
            var tests = mapper.Map<List<ADO.NET.Models.Test>, IEnumerable<TestingKnowLedgeVIS.Models.IndexTestViewModel>>(testsPerPages);
            var pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = TestRep.GetCount()};
            var ivm = new IndexViewModel { PageInfo = pageInfo, Tests = tests };
            return View(ivm);
        }

        public ActionResult PreStartTest(int testId)
        {
            return RedirectToAction("StartTest", new { testId });
        }

        public ActionResult TestStart()
        {
            /*var config = new MapperConfiguration(cfg => cfg.CreateMap<ADO.NET.Models.Quest, QuestionViewModel>());
            var mapper = config.CreateMapper();
            var question = mapper.Map<DataAcess.DomainModels.Question, QuestionViewModel>(DataAcess.TestManagment.GetQuestion(testId, questionId));
            var pageInfo = new QuestionPageInfo { TestId = testId, QuestionId = questionId, TotalPages = DataAcess.TestManagment.GetQuestionList(testId).Count };
            var stqvm = new StartTestQuestionViewModel { QuestionPageInfo = pageInfo, Question = question };
            return View(stqvm);*/
            return View();
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