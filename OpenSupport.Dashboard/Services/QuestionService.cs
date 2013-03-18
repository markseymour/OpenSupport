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
        private readonly IRepository<AnswerRecord> _answerRepository;
        private readonly IUserService _userService;

        public QuestionService(IRepository<QuestionRecord> questionRepository, IRepository<AnswerRecord> answerRepository, IUserService userService)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _userService = userService;
        }

        public void Update(QuestionRecord question)
        {
            _questionRepository.Update(question);
        }

        public QuestionRecord CreateQuestion(AskQuestionViewModel model)
        {
            var question = new QuestionRecord
                {
                    Title = model.Question.Title,
                    Body = model.Question.Body,
                    DatePosted = DateTime.Now,
                    Owner = _userService.GetCurrentUser()
                };

            _questionRepository.Add(question);

            return question;
        }

        public IEnumerable<QuestionRecord> GetAllQuestions()
        {
            return _questionRepository.FetchAll();
        }

        public QuestionRecord GetQuestion(int Id)
        {
            return GetAllQuestions().FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<AnswerRecord> GetAnswersForQuestion(int Id)
        {
            return _answerRepository.FetchAll().Where(x => x.ForQuestion.Id == Id);
        }
    }
}
