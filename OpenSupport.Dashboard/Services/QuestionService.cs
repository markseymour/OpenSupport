using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSupport.Core.Models;
using OpenSupport.Dashboard.ViewModels;
using OpenSupport.Models.Entities;
using WebMatrix.WebData;

namespace OpenSupport.Dashboard.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<QuestionRecord> _questionRepository;

        public QuestionService(IRepository<QuestionRecord> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public QuestionRecord CreateQuestion(AskQuestionViewModel model)
        {
            var question = new QuestionRecord
                {
                    Title = model.Question.Title,
                    Body = model.Question.Body,
                    DatePosted = DateTime.Now
                };

            _questionRepository.Add(question);

            return question;
        }

        public IEnumerable<QuestionRecord> GetAllQuestions()
        {
            return _questionRepository.FetchAll();
        }
    }
}
