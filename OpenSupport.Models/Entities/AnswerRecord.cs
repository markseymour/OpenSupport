using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupport.Models.Entities
{
    public class AnswerRecord : IEntity
    {
        public virtual int Id { get; set; }
        public virtual QuestionRecord ForQuestion { get; set; }
        public virtual string Answer { get; set; }
        public virtual int Votes { get; set; }
        public virtual bool IsAnswerToQuestion { get; set; }
        public virtual User Owner { get; set; }
        public virtual DateTime DatePosted { get; set; }
    }
}
