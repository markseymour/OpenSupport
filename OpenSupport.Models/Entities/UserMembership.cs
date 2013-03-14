using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupport.Models.Entities
{
    public enum Role
    {
        Administrator,
        User
    }

    public class UserMembership : IEntity
    {
        public virtual Int32 Id { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
