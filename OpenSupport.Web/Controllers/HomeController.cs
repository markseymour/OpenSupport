using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenSupport.Core.Models;
using OpenSupport.Dashboard.Services;
using OpenSupport.Models.Entities;
using OpenSupport.Web.ViewModels;

namespace OpenSupport.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuestionService _questionService;

        public HomeController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public ActionResult Index()
        {
            var questionAndAnswers = _questionService.GetAllQuestions()
                .OrderByDescending(x => x.DatePosted)
                .Select(x => new QuestionDisplay { Question = x, Answers = _questionService.GetAnswersForQuestion(x.Id) });

            var model = new IndexViewModel
            {
                SiteQuestions = questionAndAnswers
            };

            return View(model);
        }
    }
}
