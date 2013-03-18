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
            var model = new IndexViewModel
            {
                Questions = _questionService.GetAllQuestions()
            };

            return View(model);
        }
    }
}
