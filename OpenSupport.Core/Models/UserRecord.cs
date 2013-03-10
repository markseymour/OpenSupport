using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSupport.Core.Models
{
    public class UserRecord : IUser
    {
        public virtual String UserName { get; set; }
        public virtual String Email { get; set; }
        public virtual String Password { get; set; }
    }
}