using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSupport.Core.Models;
using OpenSupport.Models.Entities;

namespace OpenSupport.Dashboard.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IRepository<AnswerRecord> _answerRepository;

        public AnswerService(IRepository<AnswerRecord> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public IEnumerable<AnswerRecord> GetAnswersFor(int questionId)
        {
            return _answerRepository.Where(x => x.ForQuestion.Id == questionId);
        }
    }
}
