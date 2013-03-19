using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenSupport.Core.Services;
using OpenSupport.Dashboard.Services;
using OpenSupport.Dashboard.ViewModels;
using OpenSupport.Models.Entities;
using OpenSupport.Web.ViewModels;
using WebMatrix.WebData;

namespace OpenSupport.Web.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IReplyService _replyService;
        private readonly IAnswerService _answerService;

        public QuestionController(IQuestionService questionService, IReplyService replyService, IAnswerService answerService)
        {
            _questionService = questionService;
            _replyService = replyService;
            _answerService = answerService;
        }

        [HttpGet]
        public ActionResult Ask()
        {
            if (!WebSecurity.IsAuthenticated)
            {
                var returnUrl = String.Empty;
                if (Request.Url != null)
                    returnUrl = Request.Url.AbsolutePath;

                return RedirectToAction("Login", "Account", new { ReturnUrl = returnUrl });
            }

            return View();
        }

        [HttpPost]
        public ActionResult Ask(AskQuestionViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var newQuestion = _questionService.CreateQuestion(model);

            return RedirectToAction("Details", new { Id = newQuestion.Id });
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var question = _questionService.GetQuestion(Id);
            question.Views = question.Views + 1;
            _questionService.Update(question);

            var model = new QuestionDetailsViewModel();
            var questionAndReplies = new QuestionAndReplies
                {
                    Question = _questionService.GetQuestion(Id),
                    Replies = _replyService.GetReplies(Id)
                };

            var answersAndReplies = _answerService.GetAnswersFor(Id).Select(x => new AnswerAndReplies { Answer = x, Replies = _replyService.GetReplies(x.Id) });

            model.Question = questionAndReplies;
            model.Answers = answersAndReplies;

            return View(model);
        }
    }
}
