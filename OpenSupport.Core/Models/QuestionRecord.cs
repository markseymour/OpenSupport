using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSupport.Core.Models
{
    [Table("QuestionRecord")]
    public class QuestionRecord
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
        public Int32 Views { get; set; }
        public Int32 Votes { get; set; }
        public virtual User Owner { get; set; }
        public Boolean IsAnswered { get; set; }
        public DateTime DatePosted { get; set; }
    }
}