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
        QuestionRecord CreateQuestion(AskQuestionViewModel model);
        IEnumerable<QuestionRecord> GetAllQuestions();
    }
}
