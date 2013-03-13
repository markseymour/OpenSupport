using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenSupport.Core.Models;
using OpenSupport.Models.Entities;

namespace OpenSupport.Web.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<QuestionRecord> Questions { get; set; }
    }
}