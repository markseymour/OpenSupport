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

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
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
            var newQuestion = _questionService.CreateQuestion(model);

            return RedirectToAction("Details", new { Id = newQuestion.Id });
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            return View();
        }
    }
}
