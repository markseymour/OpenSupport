using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSupport.Core.Models;
using OpenSupport.Dashboard.ViewModels;
using OpenSupport.Models.Entities;

namespace OpenSupport.Dashboard.Services
{
    public interface IQuestionService : IDependency
    {
        void Update(QuestionRecord question);
        QuestionRecord CreateQuestion(AskQuestionViewModel model);
        QuestionRecord GetQuestion(int id);
        IEnumerable<QuestionRecord> GetAllQuestions();
        IEnumerable<AnswerRecord> GetAnswersForQuestion(int id);
    }
}
