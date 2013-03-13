using System;

namespace OpenSupport.Core.Models
{
    public class QuestionRecord : IEntity
    {
        public virtual Int32 Id { get; set; }
        public virtual String Title { get; set; }
        public virtual String Body { get; set; }
        public virtual Int32 Views { get; set; }
        public virtual Int32 Votes { get; set; }
        public virtual User Owner { get; set; }
        public virtual Boolean IsAnswered { get; set; }
        public virtual DateTime DatePosted { get; set; }
    }
}