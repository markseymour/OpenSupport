using System;

namespace OpenSupport.Models.Entities
{
    public class User : IEntity
    {
        public virtual Int32 Id { get; set; }
        public virtual String FullName { get; set; }
        public virtual String UserName { get; set; }
        public virtual String Password { get; set; }
    }
}