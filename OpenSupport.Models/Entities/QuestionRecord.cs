using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OpenSupport.Models.Entities
{
    public class QuestionRecord : IEntity
    {
        public virtual Int32 Id { get; set; }
        [Required]
        public virtual String Title { get; set; }
        [Required, AllowHtml]
        public virtual String Body { get; set; }
        public virtual Int32 Views { get; set; }
        public virtual Int32 Votes { get; set; }
        public virtual User Owner { get; set; }
        public virtual Boolean IsAnswered { get; set; }
        public virtual DateTime DatePosted { get; set; }
    }
}