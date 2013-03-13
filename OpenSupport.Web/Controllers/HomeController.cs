using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenSupport.Core.Models;
using OpenSupport.Models.Entities;
using OpenSupport.Web.ViewModels;

namespace OpenSupport.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<QuestionRecord> _questionRepo;

        public HomeController(IRepository<QuestionRecord> questionRepo)
        {
            _questionRepo = questionRepo;
        }

        public ActionResult Index()
        {
            var questions = _questionRepo.FetchAll();
            return View();
        }
    }
}
