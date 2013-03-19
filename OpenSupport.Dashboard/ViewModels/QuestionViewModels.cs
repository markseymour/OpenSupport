using System.Collections.Generic;
using OpenSupport.Models.Entities;

namespace OpenSupport.Dashboard.ViewModels
{
    public class AskQuestionViewModel
    {
        public QuestionRecord Question { get; set; }
    }

    public class QuestionAndReplies
    {
        public QuestionRecord Question { get; set; }
        public IEnumerable<ReplyRecord> Replies { get; set; }
    }

    public class AnswerAndReplies
    {
        public AnswerRecord Answer { get; set; }
        public IEnumerable<ReplyRecord> Replies { get; set; }
    }

    public class QuestionDetailsViewModel
    {
        public QuestionAndReplies Question { get; set; }
        public IEnumerable<AnswerAndReplies> Answers { get; set; }
    }
}