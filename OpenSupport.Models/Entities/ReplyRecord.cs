using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupport.Models.Entities
{
    public class ReplyRecord : IEntity 
    {
        public virtual int Id { get; set; }
        public virtual string Reply { get; set; }
        public virtual User Owner { get; set; }
        public virtual DateTime DatePosted { get; set; }
        public virtual int ReplyTo { get; set; }
    }
}
