using System;

namespace OpenSupport.Core.Models
{
    public class QuestionRecord
    {
        public virtual String Title { get; set; }
        public virtual String Body { get; set; }
        public virtual Int32 Views { get; set; }
        public virtual Int32 Votes { get; set; }
        public virtual UserRecord Owner { get; set; }
        public virtual Boolean isAnswered { get; set; }
    }
}