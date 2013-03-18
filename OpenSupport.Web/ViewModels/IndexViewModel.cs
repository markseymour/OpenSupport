using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenSupport.Core.Models;
using OpenSupport.Models.Entities;

namespace OpenSupport.Web.ViewModels
{
    public class QuestionDisplay
    {
        public QuestionRecord Question { get; set; }
        public IEnumerable<AnswerRecord> Answers { get; set; }
        //public List<TagsRecord> Tags { get; set; }
    }

    public class IndexViewModel
    {
        public IEnumerable<QuestionDisplay> SiteQuestions { get; set; }
    }
}